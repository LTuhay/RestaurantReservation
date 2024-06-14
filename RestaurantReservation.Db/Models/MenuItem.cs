
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RestaurantReservation.Db.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
