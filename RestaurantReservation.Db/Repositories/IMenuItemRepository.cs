using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IMenuItemRepository
    {
        Task<int> CreateMenuItem(MenuItem menuItem);
        Task DeleteMenuItem(int menuItemId);
        Task<List<MenuItem>> GetAllMenuItems();
        Task<List<MenuItem>> ListOrderedMenuItems(int reservationId);
        Task UpdateMenuItem(MenuItem menuItem);
    }
}