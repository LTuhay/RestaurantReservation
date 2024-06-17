using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;


namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<int> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await SaveChangesAsync();
            return order.OrderId;
        }

        public async Task UpdateOrder(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.ReservationId = order.ReservationId;
                existingOrder.EmployeeId = order.EmployeeId;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.OrderItems = order.OrderItems;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await SaveChangesAsync();
            }
        }

        public async Task<List<Order>> ListOrdersAndMenuItems(int reservationId)
        {
            return await _context.Orders
                .Where(o => o.ReservationId == reservationId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
