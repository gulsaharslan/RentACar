using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.CarPricingInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCar()
		{
			var values=_context.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand).Include(z=>z.Pricing).Where(t=>t.PricingID==2).ToList();
			return values;
		}
	}
}
