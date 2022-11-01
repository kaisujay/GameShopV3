using System.ComponentModel.DataAnnotations;

namespace GameShopV3.Models
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string PlayerId { get; set; }
        
        public int GameId{ get; set; }
    }
}
