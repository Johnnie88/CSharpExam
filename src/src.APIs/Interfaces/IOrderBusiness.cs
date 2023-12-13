using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.APIs.Interfaces
{
    public interface IOrderBusiness
    {
        public Task<Decimal> OrderResultAsync(int Id);
    }
}