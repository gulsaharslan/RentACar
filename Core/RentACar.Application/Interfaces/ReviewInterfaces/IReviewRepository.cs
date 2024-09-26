using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.ReviewInterfaces
{
	public interface IReviewRepository
	{
		public List<Review> GetReviewsByCarId(int carId);
	}
}
