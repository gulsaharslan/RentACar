using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.MailServiceCommands
{
    public class ApproveReservationCommand:IRequest
    {
        public int ReservationId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public ApproveReservationCommand(int reservationId, string email, string name)
        {
            ReservationId = reservationId;
            Email = email;
            Name = name;
        }
    }
}
