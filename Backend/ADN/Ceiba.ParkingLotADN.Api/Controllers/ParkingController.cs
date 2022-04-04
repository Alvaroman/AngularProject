using Ceiba.ParkingLotADN.Application.ParkingLot.Queries;
using Ceiba.ParkingLotADN.Application.ParkingLot.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ceiba.ParkingLotADN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController
    {
        readonly IMediator _mediator = default!;

        public ParkingController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        
        [HttpGet]
        public async Task<IEnumerable<ParkingLotDto>> GetAsync() => await _mediator.Send(new ParkingLotAllQuery());
        
        [HttpGet("{id}")]
        public async Task<ParkingLotDto> GetAsync(Guid id) => await _mediator.Send(new ParkingLotQuery(id));

        [HttpGet("{id}/cost")]
        public async Task<decimal> GetCostAsync(Guid id) => await _mediator.Send(new ParkingLotCostQuery(id));

        [HttpPost]
        public async Task PostAsync(ParkingLotCreateCommand parking) => await _mediator.Send(parking);

        [HttpPut("{id}/release")]
        public async Task<decimal> ReleaseAsync(Guid id) => await _mediator.Send(new ParkingLotReleaseAsyncCommand(id));

    }
}
