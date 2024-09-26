using MediatR;
using RentACar.Application.Features.Mediator.Queries.ReviewQueries;
using RentACar.Application.Features.Mediator.Results.ReviewsResults;
using RentACar.Application.Interfaces.ReviewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _repository;
		public GetReviewByCarIdQueryHandler(IReviewRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetReviewsByCarId(request.Id);
			return values.Select(x => new GetReviewByCarIdQueryResult
			{
				CarID = x.CarID,
				Comment = x.Comment,
				CustomerName = x.CustomerName,
				RaytingValue = x.RaytingValue,
				ReviewDate = x.ReviewDate,
				ReviewID = x.ReviewID
			}).ToList();
		}
	}
}
