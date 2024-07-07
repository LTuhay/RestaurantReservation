
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

        [NotMapped]
        public decimal TotalAmount
        {
            get
            {
                return OrderItems?.Sum(oi => oi.Quantity * oi.MenuItem.Price) ?? 0;
            }
        }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
