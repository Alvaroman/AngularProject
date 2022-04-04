using Ceiba.ParkingLotADN.Application.ParkingLot.Commands;
using Ceiba.ParkingLotADN.Domain.Services;
using MediatR;

namespace Ceiba.ParkingLotADN.Application.Person.Commands
{
    public class ParkingLotCreateHandler : AsyncRequestHandler<ParkingLotCreateCommand>
    {
        private readonly ParkingLotService _parkingLotService;

        public ParkingLotCreateHandler(ParkingLotService parkingLotService) => this._parkingLotService = parkingLotService ?? throw new ArgumentNullException(nameof(parkingLotService));

        protected override async Task Handle(ParkingLotCreateCommand request, CancellationToken cancellationToken)
        {
            _ = new ArgumentNullException(nameof(request), "request object needed to handle this task");
            var parkingLotModel = new Domain.Entities.ParkingLot
            {
                Plate = request.Plate,
                Cylinder = request.Cylinder,
                StartedAt = DateTime.Now,
                VehicleType = request.VehicleType,
                Status = true
            };
            await _parkingLotService.RegisterParkingLotAsync(parkingLotModel);
        }
    }
}
