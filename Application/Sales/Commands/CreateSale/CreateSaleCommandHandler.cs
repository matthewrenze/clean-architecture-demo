using System;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Dates;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand
        : ICreateSaleCommand
    {
        private readonly IDateService _dateService;
        private readonly IDatabaseContext _database;
        private readonly ISaleFactory _factory;

        public CreateSaleCommand(
            IDateService dateService,
            IDatabaseContext database,
            ISaleFactory factory)
        {
            _dateService = dateService;
            _database = database;
            _factory = factory;
        }

        public void Execute(CreateSaleModel model)
        {
            var date = _dateService.GetDate();

            var customer = _database.Customers
                .Find(model.CustomerId);

            var employee = _database.Employees
                .Find(model.EmployeeId);

            var product = _database.Products
                .Find(model.ProductId);

            var quantity = model.Quantity;

            var sale = _factory.Create(
                date,
                customer, 
                employee, 
                product, 
                quantity);

            _database.Sales.Add(sale);

            _database.Save();
        }
    }
}
