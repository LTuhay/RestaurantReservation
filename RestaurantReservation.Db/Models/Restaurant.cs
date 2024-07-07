using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;


namespace RestaurantReservation.Db.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string OpeningHours { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Table> Tables { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
