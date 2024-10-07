using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Features.Mediator.Commands.MailServiceCommands;
using RentACar.Application.Features.Mediator.Commands.ReservationCommands;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Queries.ReservationQueries;
using RentACar.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentACar.Application.Features.Mediator.Results.ReservationResults;
using RentACar.Application.Interfaces.MailServiceInterfaces;
using RentACar.Persistence.Context;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CarBookContext _context;
        private readonly IMailServiceRepository _mailService;
        public ReservationsController(IMediator mediator, CarBookContext context, IMailServiceRepository mailService)
        {
            _mediator = mediator;
            _context = context;
            _mailService = mailService;
        }
        [HttpGet]
        public async Task<IActionResult> RezervationList()
        {
            var values = await _mediator.Send(new GetReservationQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon başarıyla eklendi");
        }

        [HttpPost("approve/{id}")]

        public async Task<IActionResult> ApproveReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservation.IsApproved = true;
            await _context.SaveChangesAsync();
            _mailService.SendReservationApprovalEmail(reservation.Email, reservation.Name); 

            return Ok(reservation);
        }

        [HttpPost("disapprove/{id}")]

        public async Task<IActionResult> DisapproveReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservation.IsApproved = false;
            await _context.SaveChangesAsync();

            return Ok(reservation);
        }
    }
}
