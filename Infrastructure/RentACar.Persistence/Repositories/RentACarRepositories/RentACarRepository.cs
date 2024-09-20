using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.RentACarInterfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _carBookContext;

        public RentACarRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<List<Domain.Entities.RentACar>> GetByFilterAsync(Expression<Func<Domain.Entities.RentACar, bool>> filter)
        {
            var values = await _carBookContext.RentACars.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
            return values;
        }
    }
}
