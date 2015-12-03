using System;
using CleanArchitecture.Application.Core.Commands;

namespace CleanArchitecture.Application.Sales.Commands.AddSale
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
