using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IOrderItemRepository
    {
        Task<int> CreateOrderItem(OrderItem orderItem);
        Task DeleteOrderItem(int orderItemId);
        Task<List<OrderItem>> GetAllOrderItems();
        Task UpdateOrderItem(OrderItem orderItem);
    }
}