using MediatR;
using RentACar.Application.Features.Mediator.Commands.CommentCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CommandHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;
        public CreateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Comment
            {
                Description = request.Description,
                BlogID = request.BlogID,
                CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                Name = request.Name,
                Email= request.Email
            });
        }
    }
}
