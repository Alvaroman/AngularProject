using Ceiba.ParkingLotADN.Domain.Entities;
using Ceiba.ParkingLotADN.Domain.Enums;
using Ceiba.ParkingLotADN.Domain.Exception;
using Ceiba.ParkingLotADN.Domain.Extentions;
using Ceiba.ParkingLotADN.Domain.Ports;
using Ceiba.ParkingLotADN.Domain.Services.ParkingChargerState;
using Ceiba.ParkingLotADN.Domain.Services.ParkingPicoPlacaState;

namespace Ceiba.ParkingLotADN.Domain.Services
{
    [DomainService]
    public class ParkingLotService
    {
        readonly IGenericRepository<ParkingLot> _repository;
        private readonly ChargerContext _chargerContext;
        private readonly PicoPlacaContext _picoPlacaContext;

        public ParkingLotService(IGenericRepository<ParkingLot> repository, ChargerContext chargerContext, PicoPlacaContext picoPlacaContext)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository), "No repo available");
            this._chargerContext = chargerContext ?? throw new ArgumentNullException(nameof(repository), "No repo available");
            this._picoPlacaContext = picoPlacaContext;
        }


        public async Task<ParkingLot> RegisterParkingLotAsync(ParkingLot parkingLot)
        {
            if (!parkingLot.IsVehicleAllowed())
            {
                throw new VehicleNotAllowedException("You must register a valid vehicle type");
            }
            if (!_picoPlacaContext.ValidatePicoPlaca(parkingLot.Plate, (VehicleType)parkingLot.VehicleType))
            {
                throw new PicoPlacaException("Your vehicle is not allowed due to 'pico y placa' rule");
            }
            var vehicleRegistered = await _repository.GetAsync(x => x.Plate.Equals(parkingLot.Plate) && x.Status);
            if (vehicleRegistered.Any())
            {
                throw new AlreadyRegisteredException("The vehicle is already at the parking lot");
            }
            var vehiclesInUse = await _repository.GetAsync(x => x.Status && x.VehicleType == parkingLot.VehicleType);
            if (vehiclesInUse != null && vehiclesInUse.Any())
            {
                int maxCapacity = ((VehicleType)parkingLot.VehicleType).GetParkingCapacity();
                if (vehiclesInUse.Count() < maxCapacity)
                {
                    return await _repository.AddAsync(parkingLot);
                }
                else
                {
                    throw new FullCapacityException("There is no space available for this vehicle type");
                }
            }
            else
            {
                return await _repository.AddAsync(parkingLot);
            }
        }

        public async Task<decimal> ReleaseParkingLotAsync(Guid id)
        {
            var parkingLot = await _repository.GetByIdAsync(id);
            if (parkingLot == null || !parkingLot.Status)
            {
                throw new NonExistentVehicleException("This vehicle is not in the parking lot");
            }
            parkingLot.FinishedAt = DateTime.Now;
            parkingLot.Status = false;
            decimal cost = _chargerContext.CalculateCharge((int)Math.Truncate((parkingLot.FinishedAt.Value - parkingLot.StartedAt).TotalHours), parkingLot.Cylinder, (VehicleType)parkingLot.VehicleType);
            await _repository.UpdateAsync(parkingLot);
            return cost;
        }
        public async Task<decimal> GetParkingCostAsync(Guid id)
        {
            var parkingLot = await _repository.GetByIdAsync(id);
            if (parkingLot == null || !parkingLot.Status)
            {
                throw new NonExistentVehicleException("This vehicle is not in the parking lot");
            }
            return _chargerContext.CalculateCharge((int)Math.Truncate((DateTime.Now - parkingLot.StartedAt).TotalHours), parkingLot.Cylinder, (VehicleType)parkingLot.VehicleType);
        }
    }
}
