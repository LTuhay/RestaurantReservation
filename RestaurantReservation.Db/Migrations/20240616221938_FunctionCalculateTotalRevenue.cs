using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class FunctionCalculateTotalRevenue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                  @"CREATE FUNCTION dbo.CalculateTotalRevenue(@RestaurantId INT)
                    RETURNS DECIMAL(18, 2)
                    AS
                    BEGIN
                        DECLARE @TotalRevenue DECIMAL(18, 2)

                        SELECT @TotalRevenue = SUM(oi.Quantity * mi.Price)
                        FROM Orders o
                        JOIN OrderItems oi ON o.OrderId = oi.OrderId
                        JOIN MenuItems mi ON oi.MenuItemId = mi.MenuItemId
                        JOIN Reservations r ON o.ReservationId = r.ReservationId
                        WHERE r.RestaurantId = @RestaurantId

                        RETURN @TotalRevenue
                    END

                    "
              );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.CalculateTotalRevenue");
        }
    }
}
