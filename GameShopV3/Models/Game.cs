using System.ComponentModel.DataAnnotations;

namespace GameShopV3.Models
{
    public class Game
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }
    }
}
