using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IEmployeeRepository
    {
        Task<decimal> CalculateAverageOrderAmount(int employeeId);
        Task<int> CreateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task<List<Employee>> GetAllEmployees();
        Task<List<EmployeeWithRestaurant>> ListEmployeesWithRestaurants();
        Task<List<Employee>> ListManagers();
        Task UpdateEmployee(Employee employee);
    }
}