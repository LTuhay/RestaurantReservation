using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IRestaurantRepository
    {
        Task<int> CreateRestaurant(Restaurant restaurant);
        Task DeleteRestaurant(int restaurantId);
        Task<List<Restaurant>> GetAllRestaurants();
        Task<decimal> GetTotalRevenue(int restaurantId);
        Task UpdateRestaurant(Restaurant restaurant);
    }
}