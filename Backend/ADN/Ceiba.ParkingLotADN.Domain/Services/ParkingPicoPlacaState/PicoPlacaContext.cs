using Ceiba.ParkingLotADN.Domain.Enums;
using Ceiba.ParkingLotADN.Domain.Exception;

namespace Ceiba.ParkingLotADN.Domain.Services.ParkingPicoPlacaState
{
    [DomainService]
    public class PicoPlacaContext
    {
        private PicoPlacaState State { get; set; } = default!;
        public bool ValidatePicoPlaca(string plate, VehicleType vehicleType)
        {
            this.State = vehicleType switch
            {
                VehicleType.Car => new CarPicoPlaca(),
                VehicleType.Motorcycle => new MotorciclePicoPlaca(),
                _ => throw new VehicleNotAllowedException("This vehicle type is not considered")
            };
            return this.State.PicoPlacaValidator(plate);
        }
    }
}
