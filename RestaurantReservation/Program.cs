using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation;

var context = new RestaurantReservationDbContext();
var customerRepository = new CustomerRepository(context);
var employeeRepository = new EmployeeRepository(context);
var menuItemRepository = new MenuItemRepository(context);
var orderItemRepository = new OrderItemRepository(context);
var orderRepository = new OrderRepository(context);
var reservationRepository = new ReservationRepository(context);
var restaurantRepository = new RestaurantRepository(context);
var tableRepository = new TableRepository(context);

var printer = new Printer();

// CUSTOMER
printer.PrintCustomers(await customerRepository.GetAllCustomers());

var customerSample = new Customer
{
    FirstName = "Julia",
    LastName = "Doa",
    Email = "julia.doa@example.com",
    PhoneNumber = "123-456-7890"
};

var customerId = await customerRepository.CreateCustomer(customerSample);
printer.PrintCustomers(await customerRepository.GetAllCustomers());

var customerSampleToUpdate = new Customer
{
    CustomerId = customerId,
    FirstName = "Juliana",
    LastName = "Doa",
    Email = "julia.doa@example.com",
    PhoneNumber = "123-456-7880"
};

await customerRepository.UpdateCustomer(customerSampleToUpdate);
printer.PrintCustomers(await customerRepository.GetAllCustomers());

await customerRepository.DeleteCustomer(customerSampleToUpdate.CustomerId);
printer.PrintCustomers(await customerRepository.GetAllCustomers());

// RESTAURANT
printer.PrintRestaurants(await restaurantRepository.GetAllRestaurants());

var restaurantSample = new Restaurant { Name = "Restaurant Sample", Address = "321 Food St.", PhoneNumber = "111-222-3333", OpeningHours = "8 AM - 10 PM" };

var restaurantId = await restaurantRepository.CreateRestaurant(restaurantSample);
printer.PrintRestaurants(await restaurantRepository.GetAllRestaurants());

var restaurantSampleUpdate = new Restaurant { RestaurantId = restaurantId, Name = "Restaurant Sample Update", Address = "321 Food St.", PhoneNumber = "111-222-3333", OpeningHours = "8 AM - 10 PM" };

await restaurantRepository.UpdateRestaurant(restaurantSampleUpdate);
printer.PrintRestaurants(await restaurantRepository.GetAllRestaurants());

await restaurantRepository.DeleteRestaurant(restaurantId);
printer.PrintRestaurants(await restaurantRepository.GetAllRestaurants());

Console.WriteLine("Total Revenue for Restaurant 1: " + await restaurantRepository.GetTotalRevenue(1));

// TABLE
printer.PrintTables(await tableRepository.GetAllTables());

var tableSample = new Table { RestaurantId = 1, Capacity = 4 };

int tableId = await tableRepository.CreateTable(tableSample);
printer.PrintTables(await tableRepository.GetAllTables());

var tableSampleUpdate = new Table { TableId = tableId, RestaurantId = 1, Capacity = 5 };

await tableRepository.UpdateTable(tableSampleUpdate);
printer.PrintTables(await tableRepository.GetAllTables());

await tableRepository.DeleteTable(tableId);
printer.PrintTables(await tableRepository.GetAllTables());

// EMPLOYEE
printer.PrintEmployees(await employeeRepository.GetAllEmployees());

var employeeSample = new Employee { RestaurantId = 1, FirstName = "Daniel", LastName = "Green", Position = EmployeePosition.Manager };

int employeeId = await employeeRepository.CreateEmployee(employeeSample);
printer.PrintEmployees(await employeeRepository.GetAllEmployees());

var employeeSampleUpdate = new Employee { EmployeeId = employeeId, RestaurantId = 2, FirstName = "Daniel", LastName = "Greens", Position = EmployeePosition.Manager };

await employeeRepository.UpdateEmployee(employeeSampleUpdate);
printer.PrintEmployees(await employeeRepository.GetAllEmployees());

await employeeRepository.DeleteEmployee(employeeId);
printer.PrintEmployees(await employeeRepository.GetAllEmployees());

Console.WriteLine("Calculate average order amount for employee with id 1: " + await employeeRepository.CalculateAverageOrderAmount(1));

printer.PrintEmployeesWithRestaurants(await employeeRepository.ListEmployeesWithRestaurants());

printer.PrintEmployees(await employeeRepository.ListManagers());

// MENU ITEM
printer.PrintMenuItems(await menuItemRepository.GetAllMenuItems());

var menuItemSample = new MenuItem { RestaurantId = 1, Name = "Salmon Salad", Description = "Salad with salmon", Price = 15.99m };

int menuItemId = await menuItemRepository.CreateMenuItem(menuItemSample);
printer.PrintMenuItems(await menuItemRepository.GetAllMenuItems());

var menuItemSampleUpdate = new MenuItem { MenuItemId = menuItemId, RestaurantId = 1, Name = "Salmon Salad", Description = "Salad with salmon", Price = 17.99m };

await menuItemRepository.UpdateMenuItem(menuItemSampleUpdate);
printer.PrintMenuItems(await menuItemRepository.GetAllMenuItems());

await menuItemRepository.DeleteMenuItem(menuItemId);
printer.PrintMenuItems(await menuItemRepository.GetAllMenuItems());

printer.PrintMenuItems(await menuItemRepository.ListOrderedMenuItems(1));

// RESERVATION
printer.PrintReservations(await reservationRepository.GetAllReservations());

var reservationSample = new Reservation { CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Now.AddDays(1), PartySize = 3 };

int reservationId = await reservationRepository.CreateReservation(reservationSample);
printer.PrintReservations(await reservationRepository.GetAllReservations());

var reservationSampleUpdate = new Reservation { ReservationId = reservationId, CustomerId = 1, RestaurantId = 3, TableId = 1, ReservationDate = DateTime.Now.AddDays(1), PartySize = 2 };

await reservationRepository.UpdateReservation(reservationSampleUpdate);
printer.PrintReservations(await reservationRepository.GetAllReservations());

await reservationRepository.DeleteReservation(reservationId);
printer.PrintReservations(await reservationRepository.GetAllReservations());

printer.PrintReservationsWithDetails(await reservationRepository.GetReservationsWithDetails());

printer.PrintReservations(await reservationRepository.GetReservationsByCustomer(1));

// ORDER
printer.PrintOrders(await orderRepository.GetAllOrders());

var orderSample = new Order { ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Now };

int orderId = await orderRepository.CreateOrder(orderSample);
printer.PrintOrders(await orderRepository.GetAllOrders());

var orderSampleUpdate = new Order { OrderId = orderId, ReservationId = 1, EmployeeId = 1, OrderDate = DateTime.Now };

await orderRepository.UpdateOrder(orderSampleUpdate);
printer.PrintOrders(await orderRepository.GetAllOrders());

await orderRepository.DeleteOrder(orderId);
printer.PrintOrders(await orderRepository.GetAllOrders());
printer.PrintOrders(await orderRepository.ListOrdersAndMenuItems(1));

// ORDER ITEM
printer.PrintOrderItems(await orderItemRepository.GetAllOrderItems());

var orderItemSample = new OrderItem { OrderId = 1, MenuItemId = 2, Quantity = 1 };

int orderItemId = await orderItemRepository.CreateOrderItem(orderItemSample);
printer.PrintOrderItems(await orderItemRepository.GetAllOrderItems());

var orderItemSampleUpdate = new OrderItem { OrderItemId = orderItemId, OrderId = 1, MenuItemId = 2, Quantity = 2 };

await orderItemRepository.UpdateOrderItem(orderItemSampleUpdate);
printer.PrintOrderItems(await orderItemRepository.GetAllOrderItems());

await orderItemRepository.DeleteOrderItem(orderItemId);
printer.PrintOrderItems(await orderItemRepository.GetAllOrderItems());
