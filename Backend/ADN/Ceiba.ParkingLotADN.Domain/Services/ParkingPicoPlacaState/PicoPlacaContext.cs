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
                _ => new MotorciclePicoPlaca(),
            };
            return this.State.PicoPlacaValidator(plate);
        }
    }
}
