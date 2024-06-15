
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;
using Table = RestaurantReservation.Db.Models.Table;

var context = new RestaurantReservationDbContext();

// CUSTOMER

var allCustomers = GetAllCustomers();
Console.WriteLine("=== Customers ===");
foreach (var customer in allCustomers)
{
    Console.WriteLine($"Customer ID: {customer.CustomerId}");
    Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
    Console.WriteLine($"Email: {customer.Email}");
    Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
    Console.WriteLine();
}

var customerSample = new Customer
{
    FirstName = "Julia",
    LastName = "Doa",
    Email = "julia.doa@example.com",
    PhoneNumber = "123-456-7890"
};


var customerId = CreateCustomer(customerSample);

var customerSampleToUpdate = new Customer
{
    CustomerId = customerId,
    FirstName = "Juliana",
    LastName = "Doa",
    Email = "julia.doa@example.com",
    PhoneNumber = "123-456-7880"
};


UpdateCustomer(customerSampleToUpdate);


DeleteCustomer(customerSampleToUpdate.CustomerId);

List<Customer> GetAllCustomers()
{
    return context.Customers.ToList();
}
int CreateCustomer(Customer customer)
{
    context.Customers.Add(customer);
    context.SaveChanges();
    return customer.CustomerId;
}

void UpdateCustomer(Customer customer)
{
    var existingCustomer = context.Customers.Find(customer.CustomerId);
    if (existingCustomer != null)
    {
        existingCustomer.FirstName = customer.FirstName;
        existingCustomer.LastName = customer.LastName;
        existingCustomer.Email = customer.Email;
        existingCustomer.PhoneNumber = customer.PhoneNumber;

        context.SaveChanges();
    }
}

void DeleteCustomer(int customerId)
{
    var customer = context.Customers.Find(customerId);
    if (customer != null)
    {
        context.Customers.Remove(customer);
        context.SaveChanges();
    }
}


// RESTAURANT

var allRestaurants = GetAllRestaurants();
Console.WriteLine("=== Restaurants ===");
foreach (var restaurant in allRestaurants)
{
    Console.WriteLine($"Restaurant ID: {restaurant.RestaurantId}");
    Console.WriteLine($"Name: {restaurant.Name}");
    Console.WriteLine($"Address: {restaurant.Address}");
    Console.WriteLine($"Phone Number: {restaurant.PhoneNumber}");
    Console.WriteLine($"Opening Hours: {restaurant.OpeningHours}");
    Console.WriteLine();
}


var restaurantSample = new Restaurant { Name = "Restaurant Sample", Address = "321 Food St.", PhoneNumber = "111-222-3333", OpeningHours = "8 AM - 10 PM" };

var restaurantId = CreateRestaurant(restaurantSample);

var restaurantSampleUpdate = new Restaurant { RestaurantId = restaurantId, Name = "Restaurant Sample Update", Address = "321 Food St.", PhoneNumber = "111-222-3333", OpeningHours = "8 AM - 10 PM" };

UpdateRestaurant(restaurantSampleUpdate);

DeleteRestaurant(restaurantId);


List<Restaurant> GetAllRestaurants()
{
    return context.Restaurants.ToList();
}

int CreateRestaurant(Restaurant restaurant)
{
    context.Restaurants.Add(restaurant);
    context.SaveChanges();
    return restaurant.RestaurantId;
}

void UpdateRestaurant(Restaurant restaurant)
{
    var existingRestaurant = context.Restaurants.Find(restaurant.RestaurantId);
    if (existingRestaurant != null)
    {
        existingRestaurant.Name = restaurant.Name;
        existingRestaurant.Address = restaurant.Address;
        existingRestaurant.PhoneNumber = restaurant.PhoneNumber;
        existingRestaurant.OpeningHours = restaurant.OpeningHours;

        context.SaveChanges();
    }
}

void DeleteRestaurant(int restaurantId)
{
    var restaurant = context.Restaurants.Find(restaurantId);
    if (restaurant != null)
    {
        context.Restaurants.Remove(restaurant);
        context.SaveChanges();
    }
}

// TABLE

var allTables = GetAllTables();
Console.WriteLine("=== Tables ===");
foreach (var table in allTables)
{
    Console.WriteLine($"Table ID: {table.TableId}");
    Console.WriteLine($"Restaurant ID: {table.RestaurantId}");
    Console.WriteLine($"Capacity: {table.Capacity}");
    Console.WriteLine($"Number of Reservations: {table.Reservations?.Count}");
    Console.WriteLine();
}

var tableSample = new Table {RestaurantId = 1, Capacity = 4 };

int tableId = CreateTable(tableSample);

var tableSampleUpdate = new Table { TableId = tableId, RestaurantId = 1, Capacity = 5 };

UpdateTable(tableSampleUpdate);

DeleteTable(tableId);

List<Table> GetAllTables()
{
    return context.Tables.ToList();
}

int CreateTable(Table table)
{
    context.Tables.Add(table);
    context.SaveChanges();
    return table.TableId;
}

void UpdateTable(Table table)
{
    var existingTable = context.Tables.Find(table.TableId);
    if (existingTable != null)
    {
        existingTable.Capacity = table.Capacity;
        existingTable.RestaurantId = table.RestaurantId;
        existingTable.Reservations = table.Reservations;
        context.SaveChanges();
    }
}

void DeleteTable(int tableId)
{
    var table = context.Tables.Find(tableId);
    if (table != null)
    {
        context.Tables.Remove(table);
        context.SaveChanges();
    }
}


// EMPLOYEE

var allEmployees = GetAllEmployees();
Console.WriteLine("=== Employees ===");
foreach (var employee in allEmployees)
{
    Console.WriteLine($"Employee ID: {employee.EmployeeId}");
    Console.WriteLine($"Restaurant ID: {employee.RestaurantId}");
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
    Console.WriteLine($"Position: {employee.Position}");
    Console.WriteLine($"Number of Orders: {employee.Orders?.Count}");
    Console.WriteLine();
}

var employeeSample = new Employee { RestaurantId = 1, FirstName = "Daniel", LastName = "Green", Position = EmployeePosition.Manager };

int employeeId = CreateEmployee(employeeSample);

var employeeSampleUpdate = new Employee { EmployeeId = employeeId, RestaurantId = 2, FirstName = "Daniel", LastName = "Greens", Position = EmployeePosition.Manager };

UpdateEmployee(employeeSampleUpdate);

DeleteEmployee(employeeId);

List<Employee> GetAllEmployees()
{
    return context.Employees.ToList();
}

int CreateEmployee(Employee employee)
{
    context.Employees.Add(employee);
    context.SaveChanges();
    return employee.EmployeeId;
}

void UpdateEmployee(Employee employee)
{
    var existingEmployee = context.Employees.Find(employee.EmployeeId);
    if (existingEmployee != null)
    {
        existingEmployee.RestaurantId = employee.RestaurantId;
        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Position = employee.Position;
        existingEmployee.Orders = employee.Orders;
        context.SaveChanges();
    }
}

void DeleteEmployee(int employeeId)
{
    var employee = context.Employees.Find(employeeId);
    if (employee != null)
    {
        context.Employees.Remove(employee);
        context.SaveChanges();
    }
}

List<Employee> ListManagers()
{
    return context.Employees.Where(e => e.Position == EmployeePosition.Manager)
        .ToList();
}

decimal CalculateAverageOrderAmount(int employeeId)
{
    var orders = context.Orders
        .Where(o => o.EmployeeId == employeeId)
        .ToList();

    if (orders.Count == 0)
    {
        return 0;
    }

    return orders.Average(o => o.TotalAmount);
}

// MENU ITEM

var allMenuItems = GetAllMenuItems();
Console.WriteLine("=== Menu Items ===");
foreach (var menuItem in allMenuItems)
{
    Console.WriteLine($"Menu Item ID: {menuItem.MenuItemId}");
    Console.WriteLine($"Restaurant ID: {menuItem.RestaurantId}");
    Console.WriteLine($"Name: {menuItem.Name}");
    Console.WriteLine($"Description: {menuItem.Description}");
    Console.WriteLine($"Price: {menuItem.Price:C2}");
    Console.WriteLine($"Number of Order Items: {menuItem.OrderItems?.Count}");
    Console.WriteLine();
}

var menuItemSample = new MenuItem { RestaurantId = 1, Name = "Salmon Salad", Description = "Salad with salmon", Price = 15.99m };

int menuItemId = CreateMenuItem(menuItemSample);

var menuItemSampleUpdate = new MenuItem { MenuItemId = menuItemId, RestaurantId = 1, Name = "Salmon Salad", Description = "Salad with salmon", Price = 17.99m };

UpdateMenuItem(menuItemSampleUpdate);
DeleteMenuItem(menuItemId);

List<MenuItem> GetAllMenuItems()
{
    return context.MenuItems.ToList();
}

int CreateMenuItem(MenuItem menuItem)
{
    context.MenuItems.Add(menuItem);
    context.SaveChanges();
    return menuItem.MenuItemId;
}

 void UpdateMenuItem(MenuItem menuItem)
{
    var existingMenuItem = context.MenuItems.Find(menuItem.MenuItemId);
    if (existingMenuItem != null)
    {
        existingMenuItem.RestaurantId = menuItem.RestaurantId;
        existingMenuItem.Name = menuItem.Name;
        existingMenuItem.Description = menuItem.Description;
        existingMenuItem.Price = menuItem.Price;
        existingMenuItem.OrderItems = menuItem.OrderItems;
        context.SaveChanges();
    }
}

 void DeleteMenuItem(int menuItemId)
{
    var menuItem = context.MenuItems.Find(menuItemId);
    if (menuItem != null)
    {
        context.MenuItems.Remove(menuItem);
        context.SaveChanges();
    }
}

List<MenuItem> ListOrderedMenuItems(int reservationId)
{
    return context.OrderItems
        .Where(oi => oi.Order.ReservationId == reservationId)
        .Include(oi => oi.MenuItem)
        .Select(oi => oi.MenuItem)
        .Distinct()
        .ToList();

}

// RESERVATION

var allReservations = GetAllReservations();
Console.WriteLine("=== Reservations ===");
foreach (var reservation in allReservations)
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

var reservationSample = new Reservation { CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Now.AddDays(1), PartySize = 3 };

int reservationId = CreateReservation(reservationSample);

var reservationSampleUpdate = new Reservation {ReservationId = reservationId, CustomerId = 1, RestaurantId = 3, TableId = 1, ReservationDate = DateTime.Now.AddDays(1), PartySize = 2 };

UpdateReservation(reservationSampleUpdate);
DeleteReservation(reservationId);

List<Reservation> GetAllReservations()
{
    return context.Reservations.ToList();
}


int CreateReservation(Reservation reservation)
{
    context.Reservations.Add(reservation);
    context.SaveChanges();
    return reservation.ReservationId;
}

void UpdateReservation(Reservation reservation)
{
    var existingReservation = context.Reservations.Find(reservation.ReservationId);
    if (existingReservation != null)
    {
        existingReservation.CustomerId = reservation.CustomerId;
        existingReservation.RestaurantId = reservation.RestaurantId;
        existingReservation.TableId = reservation.TableId;
        existingReservation.ReservationDate = reservation. ReservationDate;
        existingReservation.PartySize = reservation.PartySize;
        existingReservation.Orders = reservation.Orders;
        context.SaveChanges();
    }
}

void DeleteReservation(int reservationId)
{
    var reservation = context.Reservations.Find(reservationId);
    if (reservation != null)
    {
        context.Reservations.Remove(reservation);
        context.SaveChanges();
    }
}

List<Reservation> GetReservationsByCustomer(int customerId)
{
    return context.Reservations
        .Where(r => r.CustomerId == customerId)
        .ToList();
}

// ORDER

var allOrders = GetAllOrders();
Console.WriteLine("=== Orders ===");
foreach (var order in allOrders)
{
    Console.WriteLine($"Order ID: {order.OrderId}");
    Console.WriteLine($"Reservation ID: {order.ReservationId}");
    Console.WriteLine($"Employee ID: {order.EmployeeId}");
    Console.WriteLine($"Order Date: {order.OrderDate}");
    Console.WriteLine($"Number of Order Items: {order.OrderItems?.Count}");
    Console.WriteLine();
}

var orderSample = new Order { ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Now };

int orderId = CreateOrder(orderSample);

var orderSampleUpdate = new Order { OrderId = orderId, ReservationId = 1, EmployeeId = 1, OrderDate = DateTime.Now };

UpdateOrder(orderSampleUpdate);

DeleteOrder(orderId);

List<Order> GetAllOrders()
{
    return context.Orders.ToList();
}

int CreateOrder(Order order)
{
    context.Orders.Add(order);
    context.SaveChanges();
    return order.OrderId;
}

 void UpdateOrder(Order order)
{
    var existingOrder = context.Orders.Find(order.OrderId);
    if (existingOrder != null)
    {
        existingOrder.ReservationId = order.ReservationId;
        existingOrder.EmployeeId = order.EmployeeId;
        existingOrder.OrderDate = order.OrderDate;
        existingOrder.OrderItems = order.OrderItems;
        context.SaveChanges();
    }
}

 void DeleteOrder(int orderId)
{
    var order = context.Orders.Find(orderId);
    if (order != null)
    {
        context.Orders.Remove(order);
        context.SaveChanges();
    }
}

List<Order> ListOrdersAndMenuItems(int reservationId)
{
    return context.Orders
        .Where(o => o.ReservationId == reservationId)
        .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.MenuItem)
        .ToList();
}

// ORDER ITEM

var allOrderItems = GetAllOrderItems();
Console.WriteLine("=== Order Items ===");
foreach (var orderItem in allOrderItems)
{
    Console.WriteLine($"Order Item ID: {orderItem.OrderItemId}");
    Console.WriteLine($"Order ID: {orderItem.OrderId}");
    Console.WriteLine($"Menu Item ID: {orderItem.MenuItemId}");
    Console.WriteLine($"Quantity: {orderItem.Quantity}");
    Console.WriteLine();
}

var orderItemSample = new OrderItem { OrderId = 1, MenuItemId = 2, Quantity = 1 };

int orderItemId = CreateOrderItem(orderItemSample);

var orderItemSampleUpdate = new OrderItem { OrderItemId = orderItemId, OrderId = 1, MenuItemId = 2, Quantity = 2 };

UpdateOrderItem(orderItemSampleUpdate);

DeleteOrderItem(orderItemId);

List<OrderItem> GetAllOrderItems()
{
    return context.OrderItems.ToList();
}

int CreateOrderItem(OrderItem orderItem)
{
    context.OrderItems.Add(orderItem);
    context.SaveChanges();
    return orderItem.OrderItemId;
}

void UpdateOrderItem(OrderItem orderItem)
{
    var existingOrderItem = context.OrderItems.Find(orderItem.OrderItemId);
    if (existingOrderItem != null)
    {
        existingOrderItem.OrderId  = orderItem.OrderId;
        existingOrderItem.MenuItemId = orderItem.MenuItemId;
        existingOrderItem.Quantity = orderItem.Quantity;
        context.SaveChanges();
    }
}

void DeleteOrderItem(int orderItemId)
{
    var orderItem = context.OrderItems.Find(orderItemId);
    if (orderItem != null)
    {
        context.OrderItems.Remove(orderItem);
        context.SaveChanges();
    }
}







