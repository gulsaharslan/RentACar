using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public async void AddNewFeatureToAllCars(Feature feature)
        {
            await _context.Features.AddAsync(feature);
            await _context.SaveChangesAsync();

            var cars = await _context.Cars.ToListAsync();

            foreach (var car in cars)
            {
                var carFeature = new CarFeature
                {
                    CarID = car.CarID,
                    FeatureID = feature.FeatureID,
                    Available = false
                };
                await _context.CarFeatures.AddAsync(carFeature);
            }

            await _context.SaveChangesAsync();
        }

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values=_context.CarFeatures.Where(x=>x.CarFeatureID == id).FirstOrDefault();
            values.Available = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public List<CarFeature> GetCarFeatureByCarId(int id)
        {
            var values=_context.CarFeatures.Include(x=>x.Feature).Where(y=>y.CarID==id).ToList();   
            return values;
        }
    }
}
