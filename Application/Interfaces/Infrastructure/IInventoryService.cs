namespace CleanArchitecture.Application.Interfaces.Infrastructure
{
    public interface IInventoryService
    {
        void NotifySaleOcurred(int productId, int quantity);
    }
}
