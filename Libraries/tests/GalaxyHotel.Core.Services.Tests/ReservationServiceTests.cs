using AutoMapper;
using GalaxyHotel.Core.Exceptions;
using GalaxyHotel.Core.Interfaces;
using GalaxyHotel.Core.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace GalaxyHotel.Core.Services.Tests
{
    public class ReservationServiceTests
    {
        private Mock<IAsyncRepository<Reservation>> reservationRepositoryMock;
        private Mock<IAsyncRepository<Room>> roomRepositoryMock;
        private Mock<IMapper> mapperMock;
        private ReservationService reservationService;
        private readonly DateTimeOffset checkInDate = DateTimeOffset.Now;
        private readonly DateTimeOffset checkOutDate = DateTimeOffset.Now.AddDays(1);
        private const int reservationId = 1;
        private const int notExistingReservationId = 2;
        private const int guestId = 1;
        private const int roomId = 1;
        private const int notExistingRoomId = 2;
        private const string roomName = "Andromeda";
        private const int roomFloor = 1;
        private const int roomTypeId = 1;
        private const decimal pricePerNight = 50;

        [SetUp]
        public void Setup()
        {
            reservationRepositoryMock = new Mock<IAsyncRepository<Reservation>>();
            roomRepositoryMock = new Mock<IAsyncRepository<Room>>();
            mapperMock = new Mock<IMapper>();

            var room = new Room { Name = roomName, Floor = roomFloor, PricePerNight = pricePerNight };
            Room notExistingRoom = null;
            roomRepositoryMock.Setup(r => r.GetByIdAsync(roomId)).ReturnsAsync(room);
            roomRepositoryMock.Setup(r => r.GetByIdAsync(notExistingRoomId)).ReturnsAsync(notExistingRoom);

            Reservation notExistingReservation = null;
            Reservation reservation = new Reservation
            {
                Id = 1,
                CheckIn = checkInDate,
                CheckOut = checkOutDate,
                GuestId = guestId,
                RoomId = roomId,
                TotalPrice = pricePerNight
            };
            reservationRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Reservation>())).Verifiable();
            reservationRepositoryMock.Setup(r => r.GetByIdAsync(reservationId)).ReturnsAsync(reservation).Verifiable();
            reservationRepositoryMock.Setup(r => r.ListAllAsync()).Verifiable();
            reservationRepositoryMock.Setup(r => r.GetByIdAsync(notExistingReservationId)).ReturnsAsync(notExistingReservation);
            reservationRepositoryMock.Setup(r => r.DeleteAsync(It.IsAny<Reservation>())).Verifiable();

            reservationService = new ReservationService(reservationRepositoryMock.Object, roomRepositoryMock.Object, mapperMock.Object);
        }

        [Test]
        public async Task CreateReservation_RoomAvailable_ReservationCreated()
        {
            await reservationService.CreateReservationAsync(checkInDate, checkOutDate, guestId, roomId);

            reservationRepositoryMock.Verify(m => m.AddAsync(It.IsAny<Reservation>()), Times.Once);
        }

        [Test]
        public void CreateReservation_RoomNotExisting_ExceptionThrown()
        {
            Assert.That(() => reservationService.CreateReservationAsync(checkInDate, checkOutDate, guestId, notExistingRoomId),
                Throws.ArgumentNullException);
        }

        [Test]
        public async Task GetReservationById_ReservationExisting_ReservationReturned()
        {
            await reservationService.GetByIdAsync(reservationId);

            reservationRepositoryMock.Verify(m => m.GetByIdAsync(reservationId), Times.Once);
        }

        [Test]
        public async Task GetReservations_ReservationsExisting_ReservationsReturned()
        {
            await reservationService.GetAll();

            reservationRepositoryMock.Verify(m => m.ListAsync(It.IsAny<ISpecification<Reservation>>()), Times.Once);
        }

        [Test]
        public async Task CancelReservation_ReservationExisting_ReservationCanceled()
        {
            await reservationService.CancelReservationAsync(reservationId);

            reservationRepositoryMock.Verify(m => m.GetByIdAsync(reservationId), Times.Once);
            reservationRepositoryMock.Verify(m => m.DeleteAsync(It.IsAny<Reservation>()), Times.Once);
        }

        [Test]
        public void CancelReservation_ReservationNotExisting_ExceptionThrown()
        {
            Assert.That(() => reservationService.CancelReservationAsync(notExistingReservationId),
                Throws.TypeOf<NotExistingReservationException>());
        }
    }
}