using System;
using System.Linq;
using CleanArchitecture.Application.Interfaces.Infrastructure;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Application.Sales.Commands.CreateSale.Factory;
using CleanArchitecture.Application.Sales.Commands.CreateSale.Repository;
using CleanArchitecture.Common.Dates;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand
        : ICreateSaleCommand
    {
        private readonly IDateService _dateService;
        private readonly ISaleRepositoryFacade _respositories;
        private readonly ISaleFactory _factory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryService _inventory;

        public CreateSaleCommand(
            IDateService dateService,
            ISaleRepositoryFacade respositories,
            ISaleFactory factory,
            IUnitOfWork unitOfWork,
            IInventoryService inventory)
        {
            _dateService = dateService;
            _respositories = respositories;
            _factory = factory;
            _unitOfWork = unitOfWork;
            _inventory = inventory;            
        }

        public void Execute(CreateSaleModel model)
        {
            var date = _dateService.GetDate();

            var customer = _respositories
                .GetCustomer(model.CustomerId);

            var employee = _respositories
                .GetEmployee(model.EmployeeId);

            var product = _respositories
                .GetProduct(model.ProductId);

            var quantity = model.Quantity;

            var sale = _factory.Create(
                date,
                customer, 
                employee, 
                product, 
                quantity);

            _respositories.AddSale(sale);

            _unitOfWork.Save();

            _inventory.NotifySaleOcurred(product.Id, quantity);
        }
    }
}
