using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace GameShopV3.Models.ViewModels
{
    public class OrderViewModel
    {
        public string PlayerId { get; set; }
        public string OrderId { get; set; }
        public string GameName { get; set; }
        public float GamePrice { get; set; }
        public DateTime PurchaseDate { get; set; }        
    }
}
