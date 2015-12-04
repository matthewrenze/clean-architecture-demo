using System;
using CleanArchitecture.Application.Core.Commands;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommandHandler 
        : ICommandHandler<CreateSaleCommand>
    {
        public void Execute(CreateSaleCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
