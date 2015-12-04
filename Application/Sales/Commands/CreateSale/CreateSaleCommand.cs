using System;
using CleanArchitecture.Application.Core.Commands;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : ICommand
    {
        private readonly CreateSaleModel _model;

        public CreateSaleCommand(CreateSaleModel model)
        {
            _model = model;
        }

        public CreateSaleModel Model
        {
            get { return _model; }
        }
    }
}
