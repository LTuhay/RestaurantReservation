using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;


namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<int> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await SaveChangesAsync();
            return employee.EmployeeId;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.RestaurantId = employee.RestaurantId;
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Position = employee.Position;
                existingEmployee.Orders = employee.Orders;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> ListManagers()
        {
            return await _context.Employees.Where(e => e.Position == EmployeePosition.Manager).ToListAsync();
        }

        public async Task<decimal> CalculateAverageOrderAmount(int employeeId)
        {
            var orders = await _context.Orders.Where(o => o.EmployeeId == employeeId).ToListAsync();
            if (orders.Count == 0)
            {
                return 0;
            }
            return orders.Average(o => o.TotalAmount);
        }

        public async Task<List<EmployeeWithRestaurant>> ListEmployeesWithRestaurants()
        {
            return await _context.EmployeesWithRestaurants.ToListAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
