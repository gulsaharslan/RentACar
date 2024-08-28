using MediatR;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Application.Interfaces.BlogInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetAllBlogWithAuthorQueryHandler : IRequestHandler<GetAllBlogWithAuthorQuery, List<GetAllBlogWithAuthorQueryResult>>
	{
		private readonly IBlogRepository _repository;
		public GetAllBlogWithAuthorQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllBlogWithAuthorQueryResult>> Handle(GetAllBlogWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetAllBlogWithAuthor();
			return values.Select(x => new GetAllBlogWithAuthorQueryResult
			{
				AuthorID = x.AuthorID,
				BlogID = x.BlogID,
				CategoryID = x.CategoryID,
				CoverImageUrl = x.ImageUrl,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
				AuthorName = x.Author.Name,
				Description=x.Description,
				AuthorDescription = x.Author.Description,
				AuthorImageUrl= x.Author.ImageUrl
			}).ToList();
		}
	}
}
