using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;


namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<int> CreateReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await SaveChangesAsync();
            return reservation.ReservationId;
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            var existingReservation = await _context.Reservations.FindAsync(reservation.ReservationId);
            if (existingReservation != null)
            {
                existingReservation.CustomerId = reservation.CustomerId;
                existingReservation.RestaurantId = reservation.RestaurantId;
                existingReservation.TableId = reservation.TableId;
                existingReservation.ReservationDate = reservation.ReservationDate;
                existingReservation.PartySize = reservation.PartySize;
                existingReservation.Orders = reservation.Orders;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteReservation(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await SaveChangesAsync();
            }
        }

        public async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
        {
            return await _context.Reservations.Where(r => r.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<ReservationWithDetails>> GetReservationsWithDetails()
        {
            return await _context.ReservationsWithDetails.ToListAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
