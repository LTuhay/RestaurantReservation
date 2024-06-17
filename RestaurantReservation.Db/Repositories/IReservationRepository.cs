using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IReservationRepository
    {
        Task<int> CreateReservation(Reservation reservation);
        Task DeleteReservation(int reservationId);
        Task<List<Reservation>> GetAllReservations();
        Task<List<Reservation>> GetReservationsByCustomer(int customerId);
        Task<List<ReservationWithDetails>> GetReservationsWithDetails();
        Task UpdateReservation(Reservation reservation);
    }
}