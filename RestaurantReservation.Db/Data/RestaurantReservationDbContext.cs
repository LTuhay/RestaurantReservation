using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Data
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<EmployeeWithRestaurant> EmployeesWithRestaurants { get; set; }

        public DbSet<ReservationWithDetails> ReservationsWithDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-4J9GHFA;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        public decimal GetTotalRevenue(int restaurantId)
        {
            var totalRevenue = this.Database
                .SqlQuery<decimal>($"SELECT dbo.CalculateTotalRevenue({restaurantId})")
                .AsEnumerable()
                .FirstOrDefault();

            return totalRevenue;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationWithDetails>()
            .HasNoKey()
            .ToView("vwReservationsWithDetails");

            modelBuilder.Entity<EmployeeWithRestaurant>()
            .HasNoKey()
            .ToView("vwEmployeesWithRestaurants");

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
                new Customer { CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "098-765-4321" },
                new Customer { CustomerId = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", PhoneNumber = "234-567-8901" },
                new Customer { CustomerId = 4, FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com", PhoneNumber = "345-678-9012" },
                new Customer { CustomerId = 5, FirstName = "David", LastName = "Wilson", Email = "david.wilson@example.com", PhoneNumber = "456-789-0123" }
            );

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { RestaurantId = 1, Name = "Gourmet Haven", Address = "123 Food St.", PhoneNumber = "111-222-3333", OpeningHours = "8 AM - 10 PM" },
                new Restaurant { RestaurantId = 2, Name = "Bistro Delight", Address = "456 Eatery Ave.", PhoneNumber = "444-555-6666", OpeningHours = "9 AM - 11 PM" },
                new Restaurant { RestaurantId = 3, Name = "Savory Spot", Address = "789 Culinary Blvd.", PhoneNumber = "777-888-9999", OpeningHours = "7 AM - 9 PM" },
                new Restaurant { RestaurantId = 4, Name = "Tasty Table", Address = "101 Dining Ln.", PhoneNumber = "101-202-3030", OpeningHours = "10 AM - 12 AM" },
                new Restaurant { RestaurantId = 5, Name = "Flavor Fiesta", Address = "202 Meal Plz.", PhoneNumber = "202-303-4040", OpeningHours = "6 AM - 8 PM" }
            );

            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
                new Table { TableId = 2, RestaurantId = 1, Capacity = 6 },
                new Table { TableId = 3, RestaurantId = 2, Capacity = 2 },
                new Table { TableId = 4, RestaurantId = 2, Capacity = 8 },
                new Table { TableId = 5, RestaurantId = 3, Capacity = 4 }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "Alice", LastName = "Brown", Position = EmployeePosition.Manager },
                new Employee { EmployeeId = 2, RestaurantId = 1, FirstName = "Bob", LastName = "White", Position = EmployeePosition.Waiter },
                new Employee { EmployeeId = 3, RestaurantId = 2, FirstName = "Charlie", LastName = "Green", Position = EmployeePosition.Chef },
                new Employee { EmployeeId = 4, RestaurantId = 3, FirstName = "Diana", LastName = "Black", Position = EmployeePosition.Bartender },
                new Employee { EmployeeId = 5, RestaurantId = 4, FirstName = "Eve", LastName = "Gray", Position = EmployeePosition.Host }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemId = 1, RestaurantId = 1, Name = "Spaghetti Carbonara", Description = "Classic Italian pasta", Price = 12.99m },
                new MenuItem { MenuItemId = 2, RestaurantId = 1, Name = "Caesar Salad", Description = "Fresh romaine lettuce", Price = 8.99m },
                new MenuItem { MenuItemId = 3, RestaurantId = 2, Name = "Grilled Salmon", Description = "Served with lemon butter", Price = 15.99m },
                new MenuItem { MenuItemId = 4, RestaurantId = 2, Name = "Beef Tacos", Description = "With salsa and guacamole", Price = 10.99m },
                new MenuItem { MenuItemId = 5, RestaurantId = 3, Name = "Margherita Pizza", Description = "Tomato, basil, mozzarella", Price = 11.99m }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Now.AddDays(1), PartySize = 2 },
                new Reservation { ReservationId = 2, CustomerId = 2, RestaurantId = 1, TableId = 2, ReservationDate = DateTime.Now.AddDays(2), PartySize = 4 },
                new Reservation { ReservationId = 3, CustomerId = 3, RestaurantId = 2, TableId = 3, ReservationDate = DateTime.Now.AddDays(3), PartySize = 2 },
                new Reservation { ReservationId = 4, CustomerId = 4, RestaurantId = 2, TableId = 4, ReservationDate = DateTime.Now.AddDays(4), PartySize = 6 },
                new Reservation { ReservationId = 5, CustomerId = 5, RestaurantId = 3, TableId = 5, ReservationDate = DateTime.Now.AddDays(5), PartySize = 4 }
            );

            modelBuilder.Entity<Order>().HasData(
                 new Order { OrderId = 1, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Now  },    
                 new Order { OrderId = 2, ReservationId = 2, EmployeeId = 2, OrderDate = DateTime.Now },
                 new Order { OrderId = 3, ReservationId = 3, EmployeeId = 3, OrderDate = DateTime.Now },
                 new Order { OrderId = 4, ReservationId = 4, EmployeeId = 3, OrderDate = DateTime.Now },
                 new Order { OrderId = 5, ReservationId = 5, EmployeeId = 4, OrderDate = DateTime.Now }
             );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, MenuItemId = 1, Quantity = 2 },
                new OrderItem { OrderItemId = 2, OrderId = 2, MenuItemId = 1, Quantity = 4 },
                new OrderItem { OrderItemId = 3, OrderId = 3, MenuItemId = 3, Quantity = 1 },
                new OrderItem { OrderItemId = 4, OrderId = 4, MenuItemId = 3, Quantity = 2 },
                new OrderItem { OrderItemId = 5, OrderId = 5, MenuItemId = 5, Quantity = 2 }
            );

        }


    }

}
