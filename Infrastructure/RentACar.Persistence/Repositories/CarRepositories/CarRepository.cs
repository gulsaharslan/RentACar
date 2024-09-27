using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.CarInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public void AddAllFeaturesToNewCar(Car car)
        {
            var features = _context.Features.ToList();
            foreach (var feature in features)
            {
                var carFeature = new CarFeature
                {
                    CarID = car.CarID,
                    FeatureID = feature.FeatureID,
                    Available = false
                };
                _context.CarFeatures.Add(carFeature);
            }

            _context.SaveChanges();

        }

        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }

		public List<Car> GetLast5CarsWithBrand()
        {
            var values=_context.Cars.Include(x => x.Brand).OrderByDescending(y=>y.CarID).Take(5).ToList();
            return values;
        }
    }
}
