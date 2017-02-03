using System;
using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Infrastructure;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Application.Sales.Commands.CreateSale.Factory;
using CleanArchitecture.Common.Dates;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand
        : ICreateSaleCommand
    {
        private readonly IDateService _dateService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRespository;
        private readonly ISaleFactory _factory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryService _inventory;

        public CreateSaleCommand(
            IDateService dateService,
            ICustomerRepository customerRepository,
            IEmployeeRepository employeeRepository,
            IProductRepository productRepository,
            ISaleRepository saleRespository,
            ISaleFactory factory,
            IUnitOfWork unitOfWork,
            IInventoryService inventory)
        {
            _dateService = dateService;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _saleRespository = saleRespository;
            _factory = factory;
            _unitOfWork = unitOfWork;
            _inventory = inventory;
        }

        public void Execute(CreateSaleModel model)
        {
            var date = _dateService.GetDate();

            var customer = _customerRepository
                .Get(model.CustomerId);

            var employee = _employeeRepository
                .Get(model.EmployeeId);

            var product = _productRepository
                .Get(model.ProductId);

            var quantity = model.Quantity;

            var sale = _factory.Create(
                date,
                customer, 
                employee, 
                product, 
                quantity);

            _saleRespository.Add(sale);

            _unitOfWork.Save();

            _inventory.NotifySaleOcurred(product.Id, quantity);
        }
    }
}
