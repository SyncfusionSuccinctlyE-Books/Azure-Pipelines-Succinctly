using GalaxyHotel.Core.Models;
using GalaxyHotel.Core.Specification;
using GalaxyHotel.Infrastructure.Data;
using GalaxyHotel.Infrastructure.IntegrationTests.SetUp;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyHotel.Infrastructure.IntegrationTests
{
    public class ReservationRepositoryTests
    {
        private SqliteConnection connection;
        private TestGalaxyHotelContext galaxyHotelContext;
        private ReservationRepository reservationRepository;
        private readonly DateTimeOffset checkInDate = DateTimeOffset.Now;
        private readonly DateTimeOffset checkOutDate = DateTimeOffset.Now.AddDays(1);
        private readonly int firstGuest = 1;
        private readonly int secondGuest = 2;
        private readonly int thirdGuest = 3;
        private readonly int secondRoom = 2;
        private readonly decimal pricePerNight = 10;

        [SetUp]
        public void Setup()
        {
            connection = new SqliteConnection("DataSource=:memory:;Foreign Keys=False");
            connection.Open();

            var options = new DbContextOptionsBuilder<GalaxyHotelContext>().UseSqlite(connection).Options;
            galaxyHotelContext = new TestGalaxyHotelContext(options);
            galaxyHotelContext.Database.EnsureCreated();

            reservationRepository = new ReservationRepository(galaxyHotelContext);
        }

        [TearDown]
        public void TearDown()
        {
            galaxyHotelContext.Dispose();
            connection.Close();
        }

        [Test]
        public async Task GetReservations_ReservationsExisting_ReservationsReturned()
        {
            var reservations = await reservationRepository.ListAllAsync();

            Assert.That(reservations.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task CountReservations_ReservationsExisting_ReservationsNumberReturned()
        {
            var reservationCount = await reservationRepository
                .CountAsync(new GuestReservationSpecification(firstGuest));

            Assert.That(reservationCount, Is.EqualTo(1));
        }

        [Test]
        public async Task GetReservationById_ReservationExisting_ReservationReturned()
        {
            var reservations = await reservationRepository
                .ListAllAsync();

            var reservation = await reservationRepository
                .GetByIdAsync(reservations.First().Id);

            Assert.That(reservation, Is.Not.Null);
        }

        [Test]
        public async Task GetReservationByGuestId_ReservationExisting_ReservationReturned()
        {
            var reservations = await reservationRepository
                .ListAsync(new GuestReservationSpecification(firstGuest));

            Assert.That(reservations.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task AddReservation_RoomAvailable_ReservationCreated()
        {
            var reservation = new Reservation
            {
                Id = 10,
                CheckIn = checkInDate,
                CheckOut = checkOutDate,
                GuestId = secondGuest,
                RoomId = secondRoom,
                TotalPrice = pricePerNight
            };

            await reservationRepository.AddAsync(reservation);

            var reservationCount = await reservationRepository
                .CountAsync(new GuestReservationSpecification(secondGuest));
            Assert.That(reservationCount, Is.EqualTo(2));
        }

        [Test]
        public async Task DeleteReservation_ReservationExisting_ReservationDeleted()
        {
            var reservation = new Reservation
            {
                Id = 11,
                CheckIn = checkInDate,
                CheckOut = checkOutDate,
                GuestId = thirdGuest,
                RoomId = secondRoom,
                TotalPrice = pricePerNight
            };

            await reservationRepository.AddAsync(reservation);

            await reservationRepository.DeleteAsync(reservation);

            var reservationCount = await reservationRepository
                .CountAsync(new GuestReservationSpecification(thirdGuest));
            Assert.That(reservationCount, Is.EqualTo(1));
        }

        [Test, Ignore("ignore")]
        public async Task UpdateReservation_ReservationExisting_ReservationUpdated()
        {
            var newPricePerNight = 50;
            var guestId = 1;
            var reservation = await reservationRepository
                .FirstAsync(new GuestReservationSpecification(guestId));

            await reservationRepository.UpdateAsync(reservation);

            reservation = await reservationRepository
                .FirstAsync(new GuestReservationSpecification(guestId));

            Assert.That(reservation.TotalPrice, Is.EqualTo(newPricePerNight));
        }

        [Test]
        public async Task GetReservationByGuestId_GuestNotExisting_NoReservationReturned()
        {
            var notExistingGuest = 5;

            var reservation = await reservationRepository
                .FirstOrDefaultAsync(new GuestReservationSpecification(notExistingGuest));

            Assert.That(reservation, Is.Null);
        }
    }
}