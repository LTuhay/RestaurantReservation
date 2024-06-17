using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> CreateCustomer(Customer customer);
        Task DeleteCustomer(int customerId);
        Task<List<Customer>> FindCustomersWithLargeReservations(int minPartySize);
        Task<List<Customer>> GetAllCustomers();
        Task UpdateCustomer(Customer customer);
    }
}