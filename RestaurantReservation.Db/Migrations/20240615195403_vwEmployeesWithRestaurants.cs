using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using RestaurantReservation.Db.Models;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class vwEmployeesWithRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW vwEmployeesWithRestaurants AS
                SELECT
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.Position,
                    r.RestaurantId,
                            r.Name AS RestaurantName,
                    r.Address AS RestaurantAddress
                FROM
                    Employees e
                JOIN
                    Restaurants r ON e.RestaurantId = r.RestaurantId;"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vwEmployeesWithRestaurants");
        }
    }
}
