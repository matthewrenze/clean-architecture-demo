namespace CleanArchitecture.Application.Interfaces.Infrastructure
{
    public interface IInventoryService
    {
        void NotifySaleOccurred(int productId, int quantity);
    }
}
