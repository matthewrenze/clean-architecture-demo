using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale.Repository
{
    public interface ISaleRepositoryFacade
    {
        Customer GetCustomer(int customerId);

        Employee GetEmployee(int employeeId);

        Product GetProduct(int productId);

        void AddSale(Sale sale);
    }
}