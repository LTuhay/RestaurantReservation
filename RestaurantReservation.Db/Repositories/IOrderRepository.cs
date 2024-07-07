using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IOrderRepository
    {
        Task<int> CreateOrder(Order order);
        Task DeleteOrder(int orderId);
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> ListOrdersAndMenuItems(int reservationId);
        Task UpdateOrder(Order order);
    }
}