using MediatR;
using RentACar.Application.Features.Mediator.Commands.MailServiceCommands;
using RentACar.Application.Interfaces.MailServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.MailServiceHandlers
{
    public class ApproveReservationCommandHandler : IRequestHandler<ApproveReservationCommand>
    {
        private readonly IMailServiceRepository _mailServiceRepository;

        public ApproveReservationCommandHandler(IMailServiceRepository mailServiceRepository)
        {
            _mailServiceRepository = mailServiceRepository;
        }

        public async Task Handle(ApproveReservationCommand request, CancellationToken cancellationToken)
        {
             _mailServiceRepository.SendReservationApprovalEmail(request.Email, request.Name);
        }
    }
}
