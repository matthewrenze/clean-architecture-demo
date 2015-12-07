using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IInventoryClient
    {
        void NotifySaleOcurred(int productId, int quantity);
    }
}
