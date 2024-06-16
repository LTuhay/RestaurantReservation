﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db.Data;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    partial class RestaurantReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.Db.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "jane.smith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            PhoneNumber = "098-765-4321"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "michael.johnson@example.com",
                            FirstName = "Michael",
                            LastName = "Johnson",
                            PhoneNumber = "234-567-8901"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "emily.davis@example.com",
                            FirstName = "Emily",
                            LastName = "Davis",
                            PhoneNumber = "345-678-9012"
                        },
                        new
                        {
                            CustomerId = 5,
                            Email = "david.wilson@example.com",
                            FirstName = "David",
                            LastName = "Wilson",
                            PhoneNumber = "456-789-0123"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "Alice",
                            LastName = "Brown",
                            Position = 0,
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Bob",
                            LastName = "White",
                            Position = 2,
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "Charlie",
                            LastName = "Green",
                            Position = 3,
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstName = "Diana",
                            LastName = "Black",
                            Position = 5,
                            RestaurantId = 3
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "Eve",
                            LastName = "Gray",
                            Position = 1,
                            RestaurantId = 4
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.EmployeeWithRestaurant", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("vwEmployeesWithRestaurants", (string)null);
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Classic Italian pasta",
                            Name = "Spaghetti Carbonara",
                            Price = 12.99m,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 2,
                            Description = "Fresh romaine lettuce",
                            Name = "Caesar Salad",
                            Price = 8.99m,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 3,
                            Description = "Served with lemon butter",
                            Name = "Grilled Salmon",
                            Price = 15.99m,
                            RestaurantId = 2
                        },
                        new
                        {
                            MenuItemId = 4,
                            Description = "With salsa and guacamole",
                            Name = "Beef Tacos",
                            Price = 10.99m,
                            RestaurantId = 2
                        },
                        new
                        {
                            MenuItemId = 5,
                            Description = "Tomato, basil, mozzarella",
                            Name = "Margherita Pizza",
                            Price = 11.99m,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2024, 6, 16, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7206),
                            ReservationId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2024, 6, 16, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7208),
                            ReservationId = 2
                        },
                        new
                        {
                            OrderId = 3,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2024, 6, 16, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7209),
                            ReservationId = 3
                        },
                        new
                        {
                            OrderId = 4,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2024, 6, 16, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7210),
                            ReservationId = 4
                        },
                        new
                        {
                            OrderId = 5,
                            EmployeeId = 4,
                            OrderDate = new DateTime(2024, 6, 16, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7212),
                            ReservationId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 2,
                            MenuItemId = 1,
                            OrderId = 2,
                            Quantity = 4
                        },
                        new
                        {
                            OrderItemId = 3,
                            MenuItemId = 3,
                            OrderId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 4,
                            MenuItemId = 3,
                            OrderId = 4,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 5,
                            MenuItemId = 5,
                            OrderId = 5,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            PartySize = 2,
                            ReservationDate = new DateTime(2024, 6, 17, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7150),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 2,
                            PartySize = 4,
                            ReservationDate = new DateTime(2024, 6, 18, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7173),
                            RestaurantId = 1,
                            TableId = 2
                        },
                        new
                        {
                            ReservationId = 3,
                            CustomerId = 3,
                            PartySize = 2,
                            ReservationDate = new DateTime(2024, 6, 19, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7175),
                            RestaurantId = 2,
                            TableId = 3
                        },
                        new
                        {
                            ReservationId = 4,
                            CustomerId = 4,
                            PartySize = 6,
                            ReservationDate = new DateTime(2024, 6, 20, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7176),
                            RestaurantId = 2,
                            TableId = 4
                        },
                        new
                        {
                            ReservationId = 5,
                            CustomerId = 5,
                            PartySize = 4,
                            ReservationDate = new DateTime(2024, 6, 21, 19, 19, 37, 539, DateTimeKind.Local).AddTicks(7178),
                            RestaurantId = 3,
                            TableId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.ReservationWithDetails", b =>
                {
                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("vwReservationsWithDetails", (string)null);
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            Address = "123 Food St.",
                            Name = "Gourmet Haven",
                            OpeningHours = "8 AM - 10 PM",
                            PhoneNumber = "111-222-3333"
                        },
                        new
                        {
                            RestaurantId = 2,
                            Address = "456 Eatery Ave.",
                            Name = "Bistro Delight",
                            OpeningHours = "9 AM - 11 PM",
                            PhoneNumber = "444-555-6666"
                        },
                        new
                        {
                            RestaurantId = 3,
                            Address = "789 Culinary Blvd.",
                            Name = "Savory Spot",
                            OpeningHours = "7 AM - 9 PM",
                            PhoneNumber = "777-888-9999"
                        },
                        new
                        {
                            RestaurantId = 4,
                            Address = "101 Dining Ln.",
                            Name = "Tasty Table",
                            OpeningHours = "10 AM - 12 AM",
                            PhoneNumber = "101-202-3030"
                        },
                        new
                        {
                            RestaurantId = 5,
                            Address = "202 Meal Plz.",
                            Name = "Flavor Fiesta",
                            OpeningHours = "6 AM - 8 PM",
                            PhoneNumber = "202-303-4040"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 6,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 2,
                            RestaurantId = 2
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 8,
                            RestaurantId = 2
                        },
                        new
                        {
                            TableId = 5,
                            Capacity = 4,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
