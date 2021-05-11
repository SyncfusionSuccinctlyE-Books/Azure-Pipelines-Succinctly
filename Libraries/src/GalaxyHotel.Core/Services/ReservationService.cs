using Ardalis.GuardClauses;
using AutoMapper;
using GalaxyHotel.Core.Extensions;
using GalaxyHotel.Core.Interfaces;
using GalaxyHotel.Core.Models;
using GalaxyHotel.Core.Specification;
using GalaxyHotel.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GalaxyHotel.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IAsyncRepository<Reservation> reservationRepository;
        private readonly IAsyncRepository<Room> roomRepository;
        private readonly IMapper mapper;

        public ReservationService(IAsyncRepository<Reservation> reservationRepository, IAsyncRepository<Room> roomRepository,
            IMapper mapper)
        {
            this.reservationRepository = reservationRepository;
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }

        public async Task CancelReservationAsync(int reservationId)
        {
            var reservation = await reservationRepository.GetByIdAsync(reservationId);
            Guard.Against.NotExistingReservation(reservation);

            await reservationRepository.DeleteAsync(reservation);
        }

        public async Task CreateReservationAsync(DateTimeOffset checkIn, DateTimeOffset checkOut, int guestId, int roomId)
        {
            var room = await roomRepository.GetByIdAsync(roomId);
            Guard.Against.Null(room, nameof(room));

            var reservation = new Reservation
            {
                CheckIn = checkIn,
                CheckOut = checkOut,
                GuestId = guestId, 
                RoomId = roomId,
                TotalPrice = room.PricePerNight
            };

            await reservationRepository.AddAsync(reservation);
        }

        public async Task<IEnumerable<ReservationDto>> GetAll()
        {
            var specification = new ReservationWithDetailsSpecification();
            var reservations = await reservationRepository.ListAsync(specification);
            return mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }

        public async Task<ReservationDto> GetByIdAsync(int reservationId)
        {
            var reservation = await reservationRepository.GetByIdAsync(reservationId);
            return mapper.Map<ReservationDto>(reservation);
        }
    }
}