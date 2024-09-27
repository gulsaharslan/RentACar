using MediatR;
using RentACar.Application.Features.Mediator.Results.AppUserResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.AppUserQueries
{
	public class GetCheckAppUserQuery:IRequest<GetCheckAppUserQueryResult>
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
