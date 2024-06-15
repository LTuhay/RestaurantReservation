using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "jane.smith@example.com", "Jane", "Smith", "098-765-4321" },
                    { 3, "michael.johnson@example.com", "Michael", "Johnson", "234-567-8901" },
                    { 4, "emily.davis@example.com", "Emily", "Davis", "345-678-9012" },
                    { 5, "david.wilson@example.com", "David", "Wilson", "456-789-0123" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Food St.", "Gourmet Haven", "8 AM - 10 PM", "111-222-3333" },
                    { 2, "456 Eatery Ave.", "Bistro Delight", "9 AM - 11 PM", "444-555-6666" },
                    { 3, "789 Culinary Blvd.", "Savory Spot", "7 AM - 9 PM", "777-888-9999" },
                    { 4, "101 Dining Ln.", "Tasty Table", "10 AM - 12 AM", "101-202-3030" },
                    { 5, "202 Meal Plz.", "Flavor Fiesta", "6 AM - 8 PM", "202-303-4040" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Alice", "Brown", 0, 1 },
                    { 2, "Bob", "White", 2, 1 },
                    { 3, "Charlie", "Green", 3, 2 },
                    { 4, "Diana", "Black", 5, 3 },
                    { 5, "Eve", "Gray", 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Classic Italian pasta", "Spaghetti Carbonara", 12.99m, 1 },
                    { 2, "Fresh romaine lettuce", "Caesar Salad", 8.99m, 1 },
                    { 3, "Served with lemon butter", "Grilled Salmon", 15.99m, 2 },
                    { 4, "With salsa and guacamole", "Beef Tacos", 10.99m, 2 },
                    { 5, "Tomato, basil, mozzarella", "Margherita Pizza", 11.99m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 6, 1 },
                    { 3, 2, 2 },
                    { 4, 8, 2 },
                    { 5, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2024, 6, 16, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6183), 1, 1 },
                    { 2, 2, 4, new DateTime(2024, 6, 17, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6202), 1, 2 },
                    { 3, 3, 2, new DateTime(2024, 6, 18, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6204), 2, 3 },
                    { 4, 4, 6, new DateTime(2024, 6, 19, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6205), 2, 4 },
                    { 5, 5, 4, new DateTime(2024, 6, 20, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6207), 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 6, 15, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6226), 1 },
                    { 2, 2, new DateTime(2024, 6, 15, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6228), 2 },
                    { 3, 3, new DateTime(2024, 6, 15, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6229), 3 },
                    { 4, 3, new DateTime(2024, 6, 15, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6230), 4 },
                    { 5, 4, new DateTime(2024, 6, 15, 12, 42, 55, 6, DateTimeKind.Local).AddTicks(6231), 5 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 2, 4 },
                    { 3, 3, 3, 1 },
                    { 4, 3, 4, 2 },
                    { 5, 5, 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);
        }
    }
}
