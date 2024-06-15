
using System.ComponentModel.DataAnnotations;


namespace RestaurantReservation.Db.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public EmployeePosition Position { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
