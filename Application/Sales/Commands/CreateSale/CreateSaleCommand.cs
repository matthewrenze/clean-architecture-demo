using System;
using System.Linq;
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
        private readonly IInventoryClient _client;

        public CreateSaleCommand(
            IDateService dateService,
            IDatabaseContext database,
            ISaleFactory factory,
            IInventoryClient client)
        {
            _dateService = dateService;
            _database = database;
            _factory = factory;
            _client = client;
        }

        public void Execute(CreateSaleModel model)
        {
            var date = _dateService.GetDate();

            var customer = _database.Customers
                .First(p => p.Id == model.CustomerId);

            var employee = _database.Employees
                .First(p => p.Id == model.EmployeeId);

            var product = _database.Products
                .First(p => p.Id == model.ProductId);

            var quantity = model.Quantity;

            var sale = _factory.Create(
                date,
                customer, 
                employee, 
                product, 
                quantity);

            _database.Sales.Add(sale);

            _database.Save();

            _client.NotifySaleOcurred(product.Id, quantity);
        }
    }
}
