using GalaxyHotel.Core.Models;
using GalaxyHotel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace GalaxyHotel.Infrastructure.IntegrationTests.SetUp
{
    public class TestGalaxyHotelContext : GalaxyHotelContext
    {
        private static DateTimeOffset checkInDate = DateTimeOffset.Now;
        private static DateTimeOffset checkOutDate = DateTimeOffset.Now.AddDays(1);

        public TestGalaxyHotelContext(DbContextOptions<GalaxyHotelContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
               .HasOne(r => r.Guest)
               .WithMany(r => r.Reservations)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(r => r.Reservations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guest>()
                .HasMany(g => g.Reservations)
                .WithOne(g => g.Guest)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guest>()
                .HasOne(g => g.Address)
                .WithOne(g => g.Guest)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guest>()
                .HasOne(g => g.PaymentMethod)
                .WithOne(g => g.Guest)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>()
                .HasOne(g => g.Guest)
                .WithOne(g => g.Address)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PaymentMethod>()
                .HasOne(g => g.Guest)
                .WithOne(g => g.PaymentMethod)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = 1, Alias = "Private Credit Card 1", CardNumber = "123412349876598765", DueDate = DateTimeOffset.Now.AddYears(1) },
                new PaymentMethod { Id = 2, Alias = "Private Credit Card 2", CardNumber = "123412349876598766", DueDate = DateTimeOffset.Now.AddYears(1) },
                new PaymentMethod { Id = 3, Alias = "Private Credit Card 3", CardNumber = "123412349876598767", DueDate = DateTimeOffset.Now.AddYears(1) },
                new PaymentMethod { Id = 4, Alias = "Private Credit Card 4", CardNumber = "123412349876598768", DueDate = DateTimeOffset.Now.AddYears(1) });

            modelBuilder.Entity<Address>().HasData(
                    new Address { Id = 1, City = "New York", Street = "13th Space Road, Brooklyn", Country = "United States of America", State = "New York", ZipCode = "13021" },
                    new Address { Id = 2, City = "Los Angeles", Street = "12th Hollywood road, Hollywood", Country = "United States of America", State = "New York", ZipCode = "33024" },
                    new Address { Id = 3, City = "Naples", Street = "Piazza Plebiscito 1, Naples", Country = "Italy", State = "", ZipCode = "80100" },
                    new Address { Id = 4, City = "London", Street = "14th Valley Road", Country = "United States of America", State = "New York", ZipCode = "WC2N 5DU" });

            modelBuilder.Entity<Guest>().HasData(
                    new Guest { Id = 1, FirstName = "John", LastName = "Doe", AddressId = 1, PaymentMethodId = 1 },
                    new Guest { Id = 2, FirstName = "Alex", LastName = "Harvey", AddressId = 2, PaymentMethodId = 2 },
                    new Guest { Id = 3, FirstName = "Antonio", LastName = "Esposito", AddressId = 3, PaymentMethodId = 3 },
                    new Guest { Id = 4, FirstName = "Mark", LastName = "River", AddressId = 4, PaymentMethodId = 4 });

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Floor = 1,
                    Name = "Andromeda",
                    PricePerNight = 200
                },
                new Room
                {
                    Id = 2,
                    Floor = 1,
                    Name = "Whirpool",
                    PricePerNight = 150
                },
                new Room
                {
                    Id = 3,
                    Floor = 1,
                    Name = "Sombrero",
                    PricePerNight = 100
                });

            modelBuilder.Entity<Reservation>().HasData(
                    new Reservation
                    {
                        Id = 1,
                        CheckIn = checkInDate,
                        CheckOut = checkOutDate,
                        GuestId = 1,
                        RoomId = 1,
                        TotalPrice = 200
                    },
                    new Reservation
                    {
                        Id = 2,
                        CheckIn = checkInDate,
                        CheckOut = checkOutDate,
                        GuestId = 2,
                        RoomId = 2,
                        TotalPrice = 150
                    },
                    new Reservation
                    {
                        Id = 3,
                        CheckIn = checkInDate,
                        CheckOut = checkOutDate,
                        GuestId = 3,
                        RoomId = 3,
                        TotalPrice = 100

                    });
        }
    }
}
