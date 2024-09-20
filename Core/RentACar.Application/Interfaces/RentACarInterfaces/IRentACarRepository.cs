using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
        Task<List<RentACar.Domain.Entities.RentACar>> GetByFilterAsync(Expression<Func<RentACar.Domain.Entities.RentACar, bool>> filter);
    }
}
