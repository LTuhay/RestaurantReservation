using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface ITableRepository
    {
        Task<int> CreateTable(Table table);
        Task DeleteTable(int tableId);
        Task<List<Table>> GetAllTables();
        Task UpdateTable(Table table);
    }
}