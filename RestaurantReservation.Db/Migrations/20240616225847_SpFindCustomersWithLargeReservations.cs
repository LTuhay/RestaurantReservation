using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SpFindCustomersWithLargeReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                 @"CREATE PROCEDURE dbo.SpFindCustomersWithLargeReservations
                        @MinPartySize INT
                    AS
                    BEGIN
                        SELECT DISTINCT c.CustomerId, c.FirstName, c.LastName, c.Email, c.PhoneNumber
                        FROM Customers c
                        JOIN Reservations r ON c.CustomerId = r.CustomerId
                        WHERE r.PartySize > @MinPartySize
                    END
                    "
             );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.SpFindCustomersWithLargeReservations");
        }
    }
}
