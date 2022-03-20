﻿using FooBar.Domain.Services;
using MediatR;

namespace FooBar.Application.Person.Commands
{
    public class ParkingLotReleaseAsyncHandler : IRequestHandler<ParkingLotReleaseAsyncCommand,decimal>
    {
        private readonly ParkingLotService _parkingLotService;

        public ParkingLotReleaseAsyncHandler(ParkingLotService parkingLotService) => this._parkingLotService = parkingLotService;

        public async Task<decimal> Handle(ParkingLotReleaseAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = new ArgumentNullException(nameof(request), "request object needed to handle this task");

            return await _parkingLotService.ReleaseParkingLotAsync(request.id);
        }

    }

}
