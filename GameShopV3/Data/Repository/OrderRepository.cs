using GameShopV3.Models;
using GameShopV3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameShopV3.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GameShopDbContext _shopDbContext;
        private readonly ICartRepository _cartRepository;
        private readonly IPlayerServices _playerServices;

        public OrderRepository(GameShopDbContext shopDbContext, ICartRepository cartRepository, IPlayerServices playerServices)
        {
            _shopDbContext = shopDbContext;
            _cartRepository = cartRepository;
            _playerServices = playerServices;
        }
        public async Task<IEnumerable<OrderViewModel>> GetOrderbyPlayerIdAsync()
        {
            var playerId = _playerServices.GetUserId();

            var res = await _shopDbContext.Orders
                .Include(x => x.Game)
                .Include(x => x.Player)
                .Where(x => x.GameId == x.Game.Id && x.PlayerId == x.Player.Id && x.PlayerId == playerId)
                .Select(x => new OrderViewModel()
                {
                    PlayerId = x.PlayerId,
                    OrderId = x.OrderId,
                    GameName = x.Game.Name,
                    GamePrice = x.Game.Price,
                    PurchaseDate = x.PurchaseDate
                }).ToListAsync();

            return res;
        }
        
        public async Task CreateOrderAsync()
        {
            var collectionCart = await _cartRepository.ReadCartAsync(_playerServices.GetUserId());

            var orderId = Guid.NewGuid().ToString();

            foreach (var item in collectionCart)
            {
                var orderItem = new Order()
                {
                    PlayerId = item.PlayerId,
                    GameId = item.GameId,
                    PurchaseDate = DateTime.Now,
                };
                orderItem.OrderId = orderId;

                _shopDbContext.Orders.Add(orderItem);
                await _shopDbContext.SaveChangesAsync();

                await _cartRepository.EmptyCartAsync(_playerServices.GetUserId());  //Need to Empty Cart after Order has created
            }
        }
    }
}
