using MediatR;
using RentACar.Application.Features.Mediator.Results.StatisticsResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountByTranmissionIsAutoQuery : IRequest<GetCarCountByTranmissionIsAutoQueryResult>
    {
    }
}
