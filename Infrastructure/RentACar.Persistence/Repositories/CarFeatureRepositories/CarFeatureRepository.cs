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

        public void AddNewFeatureToAllCars(Feature feature)
        {

            var cars =  _context.Cars.ToList();

            foreach (var car in cars)
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
