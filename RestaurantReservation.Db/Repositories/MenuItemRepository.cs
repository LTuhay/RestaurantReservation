using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;


namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<int> CreateMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await SaveChangesAsync();
            return menuItem.MenuItemId;
        }

        public async Task UpdateMenuItem(MenuItem menuItem)
        {
            var existingMenuItem = await _context.MenuItems.FindAsync(menuItem.MenuItemId);
            if (existingMenuItem != null)
            {
                existingMenuItem.RestaurantId = menuItem.RestaurantId;
                existingMenuItem.Name = menuItem.Name;
                existingMenuItem.Description = menuItem.Description;
                existingMenuItem.Price = menuItem.Price;
                existingMenuItem.OrderItems = menuItem.OrderItems;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteMenuItem(int menuItemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(menuItemId);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await SaveChangesAsync();
            }
        }

        public async Task<List<MenuItem>> ListOrderedMenuItems(int reservationId)
        {
            return await _context.OrderItems
                .Where(oi => oi.Order.ReservationId == reservationId)
                .Include(oi => oi.MenuItem)
                .Select(oi => oi.MenuItem)
                .Distinct()
                .ToListAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
