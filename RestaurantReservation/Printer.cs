using RestaurantReservation.Db.Models;

namespace RestaurantReservation
{
    public class Printer
    {
        public void PrintCustomers(IEnumerable<Customer> customers)
        {
            Console.WriteLine("=== Customers ===");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}");
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                Console.WriteLine();
            }
        }

        public void PrintRestaurants(IEnumerable<Restaurant> restaurants)
        {
            Console.WriteLine("=== Restaurants ===");
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"Restaurant ID: {restaurant.RestaurantId}");
                Console.WriteLine($"Name: {restaurant.Name}");
                Console.WriteLine($"Address: {restaurant.Address}");
                Console.WriteLine($"Phone Number: {restaurant.PhoneNumber}");
                Console.WriteLine($"Opening Hours: {restaurant.OpeningHours}");
                Console.WriteLine();
            }
        }

        public void PrintTables(IEnumerable<Table> tables)
        {
            Console.WriteLine("=== Tables ===");
            foreach (var table in tables)
            {
                Console.WriteLine($"Table ID: {table.TableId}");
                Console.WriteLine($"Restaurant ID: {table.RestaurantId}");
                Console.WriteLine($"Capacity: {table.Capacity}");
                Console.WriteLine($"Number of Reservations: {table.Reservations?.Count}");
                Console.WriteLine();
            }
        }

        public void PrintEmployees(IEnumerable<Employee> employees)
        {
            Console.WriteLine("=== Employees ===");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.EmployeeId}");
                Console.WriteLine($"Restaurant ID: {employee.RestaurantId}");
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
                Console.WriteLine($"Position: {employee.Position}");
                Console.WriteLine($"Number of Orders: {employee.Orders?.Count}");
                Console.WriteLine();
            }
        }

        public void PrintEmployeesWithRestaurants(IEnumerable<EmployeeWithRestaurant> employeesWithRestaurants)
        {
            Console.WriteLine("=== Employees with restaurants ===");
            foreach (var employeeWithRestaurant in employeesWithRestaurants)
            {
                Console.WriteLine($"Employee ID: {employeeWithRestaurant.EmployeeId}");
                Console.WriteLine($"Name: {employeeWithRestaurant.FirstName} {employeeWithRestaurant.LastName}");
                Console.WriteLine($"Position: {employeeWithRestaurant.Position}");
                Console.WriteLine($"Restaurant ID: {employeeWithRestaurant.RestaurantId}");
                Console.WriteLine($"Restaurant Name: {employeeWithRestaurant.RestaurantName}");
                Console.WriteLine($"Restaurant Address: {employeeWithRestaurant.RestaurantAddress}");
                Console.WriteLine();
            }
        }

        public void PrintMenuItems(IEnumerable<MenuItem> menuItems)
        {
            Console.WriteLine("=== Menu Items ===");
            foreach (var menuItem in menuItems)
            {
                Console.WriteLine($"Menu Item ID: {menuItem.MenuItemId}");
                Console.WriteLine($"Restaurant ID: {menuItem.RestaurantId}");
                Console.WriteLine($"Name: {menuItem.Name}");
                Console.WriteLine($"Description: {menuItem.Description}");
                Console.WriteLine($"Price: {menuItem.Price:C2}");
                Console.WriteLine($"Number of Order Items: {menuItem.OrderItems?.Count}");
                Console.WriteLine();
            }
        }

        public void PrintReservations(IEnumerable<Reservation> reservations)
        {
            Console.WriteLine("=== Reservations ===");
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
                Console.WriteLine($"Customer ID: {reservation.CustomerId}");
                Console.WriteLine($"Restaurant ID: {reservation.RestaurantId}");
                Console.WriteLine($"Table ID: {reservation.TableId}");
                Console.WriteLine($"Reservation Date: {reservation.ReservationDate}");
                Console.WriteLine($"Party Size: {reservation.PartySize}");
                Console.WriteLine($"Number of Orders: {reservation.Orders?.Count}");
                Console.WriteLine();
            }
        }

        public void PrintReservationsWithDetails(IEnumerable<ReservationWithDetails> reservations)
        {
            Console.WriteLine("=== Reservations with details ===");
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
                Console.WriteLine($"Reservation Date: {reservation.ReservationDate}");
                Console.WriteLine($"Party Size: {reservation.PartySize}");
                Console.WriteLine($"Customer: {reservation.CustomerFirstName} {reservation.CustomerLastName} ({reservation.CustomerEmail})");
                Console.WriteLine($"Restaurant: {reservation.RestaurantName} ({reservation.RestaurantAddress})");
                Console.WriteLine();
            }
        }

        public void PrintOrders(IEnumerable<Order> orders)
        {
            Console.WriteLine("=== Orders ===");
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}");
                Console.WriteLine($"Reservation ID: {order.ReservationId}");
                Console.WriteLine($"Employee ID: {order.EmployeeId}");
                Console.WriteLine($"Order Date: {order.OrderDate}");
                Console.WriteLine($"Number of Order Items: {order.OrderItems?.Count}");
                Console.WriteLine();
            }
        }

        public void PrintOrderItems(IEnumerable<OrderItem> orderItems)
        {
            Console.WriteLine("=== Order Items ===");
            foreach (var orderItem in orderItems)
            {
                Console.WriteLine($"Order Item ID: {orderItem.OrderItemId}");
                Console.WriteLine($"Order ID: {orderItem.OrderId}");
                Console.WriteLine($"Menu Item ID: {orderItem.MenuItemId}");
                Console.WriteLine($"Quantity: {orderItem.Quantity}");
                Console.WriteLine();
            }
        }

    }
}
