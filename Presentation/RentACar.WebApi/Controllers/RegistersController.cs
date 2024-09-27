using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.RegisterCommands;

namespace RentACar.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RegistersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]

		public async Task<IActionResult> CreateUser(CreateAppUserCommand command)
		{
			await _mediator.Send(command);
			return Ok("Kullanıcı eklendi");
		}
	}
}
