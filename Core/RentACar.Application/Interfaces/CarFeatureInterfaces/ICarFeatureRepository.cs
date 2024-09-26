using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeatureByCarId(int id);
        void ChangeCarFeatureAvailableToFalse(int id);
        void ChangeCarFeatureAvailableToTrue(int id);
        void AddNewFeatureToAllCars(Feature feature);
    }
}
