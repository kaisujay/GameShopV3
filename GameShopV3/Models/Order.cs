using GameShopV3.Application;
using System.ComponentModel.DataAnnotations;

namespace GameShopV3.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string OrderId { get; set; }
        public ApplicationUser Player { get; set; }
        public string PlayerId { get; set; }  //This has to be string as per AspNetUser Table
        public Game Game { get; set; }
        public int GameId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
