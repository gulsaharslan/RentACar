﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Queries.AppUserQueries;
using RentACar.Application.Tools;

namespace RentACar.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LoginsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Index(GetCheckAppUserQuery query)
		{
			var values = await _mediator.Send(query);
			if (values.IsExist)
			{
				return Created("", JwtTokenGenerator.GenerateToken(values));
			}
			else
			{
				return BadRequest("Kullanıcı adı veya şifre hatalıdır");
			}
		}
	}
}
