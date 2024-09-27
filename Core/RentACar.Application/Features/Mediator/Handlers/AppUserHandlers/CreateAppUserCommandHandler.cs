using MediatR;
using RentACar.Application.Enums;
using RentACar.Application.Features.Mediator.Commands.RegisterCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
	{
		private readonly IRepository<AppUser> _repository;

		public CreateAppUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
		 await _repository.CreateAsync(new AppUser
			{
             Password = request.Password,
             Username = request.Username,
             AppRoleId = (int)RoleTypes.Member,
             Email = request.Email,
             Name = request.Name,
             Surname = request.Surname
         });
		}
	}
}
