using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;


namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderItem>> GetAllOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<int> CreateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await SaveChangesAsync();
            return orderItem.OrderItemId;
        }

        public async Task UpdateOrderItem(OrderItem orderItem)
        {
            var existingOrderItem = await _context.OrderItems.FindAsync(orderItem.OrderItemId);
            if (existingOrderItem != null)
            {
                existingOrderItem.OrderId = orderItem.OrderId;
                existingOrderItem.MenuItemId = orderItem.MenuItemId;
                existingOrderItem.Quantity = orderItem.Quantity;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteOrderItem(int orderItemId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderItemId);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await SaveChangesAsync();
            }
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
