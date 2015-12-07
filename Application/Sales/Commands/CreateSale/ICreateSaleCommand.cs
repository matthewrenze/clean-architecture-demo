namespace CleanArchitecture.Application.Sales.Commands.CreateSale
{
    public interface ICreateSaleCommand
    {
        void Execute(CreateSaleModel model);
    }
}