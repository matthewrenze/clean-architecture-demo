using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface ISaleRepository : IRepository<Sale>
    {
    }
}
