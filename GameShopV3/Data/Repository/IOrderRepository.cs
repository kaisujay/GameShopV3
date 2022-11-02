using GameShopV3.Models.ViewModels;

namespace GameShopV3.Data.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderViewModel>> GetOrderbyPlayerIdAsync();
        Task CreateOrderAsync();
    }
}