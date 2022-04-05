using Ceiba.ParkingLotADN.Domain.Enums;
using Ceiba.ParkingLotADN.Domain.Exception;

namespace Ceiba.ParkingLotADN.Domain.Services.ParkingChargerState
{
    [DomainService]
    public class ChargerContext
    {
        private ChargerState State { get; set; } = default!;
        public decimal CalculateCharge(int spentHours, int cylinder, VehicleType vehicleType)
        {
            this.State = vehicleType switch
            {
                VehicleType.Car => new CarCharger(),
                _ => new MotorcycleCharger()
            };
            return this.State.Calculate(spentHours, cylinder);
        }
    }
}
    