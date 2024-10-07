using MediatR;
using RentACar.Application.Features.Mediator.Results.ReservationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationQuery:IRequest<List<GetReservationQueryResult>>
    {
    }
}
