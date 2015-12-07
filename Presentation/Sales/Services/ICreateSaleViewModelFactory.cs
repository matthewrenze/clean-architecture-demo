using CleanArchitecture.Presentation.Sales.Models;

namespace CleanArchitecture.Presentation.Sales.Services
{
    public interface ICreateSaleViewModelFactory
    {
        CreateSaleViewModel Create();
    }
}