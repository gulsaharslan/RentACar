using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudience = "https://localhost";
		public const string ValidIssuer = "http://localhost";
		public const string Key = "180323++Car*BOOK01.Car*BOOK01.180323++";
		public const int Expire = 3;
	}
}
