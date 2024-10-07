using MediatR;
using RentACar.Application.Features.Mediator.Queries.ReservationQueries;
using RentACar.Application.Features.Mediator.Results.PricingResults;
using RentACar.Application.Features.Mediator.Results.ReservationResults;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.ReservationInterfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values =  _reservationRepository.GetReservationsWithLocationAndCar();

       
            return values.Select(x => new GetReservationQueryResult
            {
                Age = x.Age,
                CarID = x.CarID,
                Description = x.Description,
                DriverLicenseYear = x.DriverLicenseYear,
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                Surname = x.Surname,
                Status = x.Status,
                DropOffLocationID = x.DropOffLocationID,
                DropOffLocationName = x.DropOffLocation?.Name,  
                PickUpLocationID = x.PickUpLocationID,
                PickUpLocationName = x.PickUpLocation?.Name,   
                CarModel = x.Car?.Model,
                ReservationID=x.ReservationID,
                IsApproved = x.IsApproved,
            }).ToList();
        }
    }
}
