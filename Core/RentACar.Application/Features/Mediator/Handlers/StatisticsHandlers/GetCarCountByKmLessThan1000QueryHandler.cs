using MediatR;
using RentACar.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACar.Application.Features.Mediator.Results.StatisticsResults;
using RentACar.Application.Interfaces.StatisticsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByKmLessThan1000QueryHandler:IRequestHandler<GetCarCountByKmLessThan1000Query,GetCarCountByKmLessThan1000QueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByKmLessThan1000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByKmLessThan1000QueryResult> Handle(GetCarCountByKmLessThan1000Query request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByKmLessThan1000();
            return new GetCarCountByKmLessThan1000QueryResult
            {
                CarCountByKmLessThan1000 = value
            };
        }
    }
}
