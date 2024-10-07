using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.ReservationInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarBookContext _context;

        public ReservationRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Reservation> GetReservationsWithLocationAndCar()
        {
            return _context.Reservations
        .Include(x => x.PickUpLocation) 
        .Include(y => y.DropOffLocation) 
        .Include(z => z.Car) 
        .ToList();
        }
    }
}
