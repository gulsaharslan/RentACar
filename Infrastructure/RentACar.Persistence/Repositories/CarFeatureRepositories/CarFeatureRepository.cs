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

        public List<CarFeature> GetCarFeatureByCarId(int id)
        {
            var values=_context.CarFeatures.Include(x=>x.Feature).Where(y=>y.CarID==id).ToList();   
            return values;
        }
    }
}
