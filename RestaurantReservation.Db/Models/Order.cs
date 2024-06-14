
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RestaurantReservation.Db.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
