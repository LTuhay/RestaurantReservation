using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public CustomerRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<int> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await SaveChangesAsync();
            return customer.CustomerId;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteCustomer(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await SaveChangesAsync();
            }
        }

        public Task<List<Customer>> FindCustomersWithLargeReservations(int minPartySize)
        {
            return Task.FromResult(_context.FindCustomersWithLargeReservations(minPartySize));
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
