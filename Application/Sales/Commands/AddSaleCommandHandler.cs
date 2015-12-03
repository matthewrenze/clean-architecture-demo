using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Core.Commands;

namespace CleanArchitecture.Application.Sales.Commands
{
    public class AddSaleCommandHandler 
        : ICommandHandler<AddSaleCommand>
    {
        public void Execute(AddSaleCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
