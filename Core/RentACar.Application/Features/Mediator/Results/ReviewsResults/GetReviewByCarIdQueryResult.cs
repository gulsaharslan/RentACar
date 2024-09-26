using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Results.ReviewsResults
{
	public class GetReviewByCarIdQueryResult
	{
		public int ReviewID { get; set; }
		public string CustomerName { get; set; }
		public string Comment { get; set; }
		public int RaytingValue { get; set; }
		public DateTime ReviewDate { get; set; }
		public int CarID { get; set; }
	}
}
