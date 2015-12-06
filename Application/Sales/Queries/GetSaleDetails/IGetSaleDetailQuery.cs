namespace CleanArchitecture.Application.Sales.Queries.GetSaleDetails
{
    public interface IGetSaleDetailQuery
    {
        SaleDetailModel Execute(int id);
    }
}