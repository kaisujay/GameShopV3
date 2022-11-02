using GameShopV3.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GameShopV3.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _orderRepository.GetOrderbyPlayerIdAsync();
            return View(res);
        }

        public async Task<IActionResult> CreateOrder()
        {
            await _orderRepository.CreateOrderAsync();
            return RedirectToAction("Index","Order");
        }
    }
}
