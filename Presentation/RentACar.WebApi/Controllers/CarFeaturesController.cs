using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Features.Mediator.Queries.CarFeatureQueries;
using RentACar.Persistence.Migrations;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpGet("CarFeatureChangeAvaiblableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvaiblableToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("CarFeatureChangeAvaiblableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvaiblableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Güncelleme yapıldı");
        }

        [HttpPost("AddNewFeature")]
        public async Task<IActionResult> AddNewFeatureToAllCars(CreateFeatureWithCarFeaturesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yeni özellik eklendi");
        }
    }
}
