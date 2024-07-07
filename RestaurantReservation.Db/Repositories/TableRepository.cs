using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Table>> GetAllTables()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<int> CreateTable(Table table)
        {
            _context.Tables.Add(table);
            await SaveChangesAsync();
            return table.TableId;
        }

        public async Task UpdateTable(Table table)
        {
            var existingTable = await _context.Tables.FindAsync(table.TableId);
            if (existingTable != null)
            {
                existingTable.Capacity = table.Capacity;
                existingTable.RestaurantId = table.RestaurantId;
                existingTable.Reservations = table.Reservations;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteTable(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if (table != null)
            {
                _context.Tables.Remove(table);
                await SaveChangesAsync();
            }
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}