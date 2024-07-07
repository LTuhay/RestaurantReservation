using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;


namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<int> CreateRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await SaveChangesAsync();
            return restaurant.RestaurantId;
        }

        public async Task UpdateRestaurant(Restaurant restaurant)
        {
            var existingRestaurant = await _context.Restaurants.FindAsync(restaurant.RestaurantId);
            if (existingRestaurant != null)
            {
                existingRestaurant.Name = restaurant.Name;
                existingRestaurant.Address = restaurant.Address;
                existingRestaurant.PhoneNumber = restaurant.PhoneNumber;
                existingRestaurant.OpeningHours = restaurant.OpeningHours;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteRestaurant(int restaurantId)
        {
            var restaurant = await _context.Restaurants.FindAsync(restaurantId);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await SaveChangesAsync();
            }
        }

        public async Task<decimal> GetTotalRevenue(int restaurantId)
        {
            return await Task.FromResult(_context.GetTotalRevenue(restaurantId));
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
