using GalaxyHotel.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GalaxyHotel.Core.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDto>> GetAll();
        Task<ReservationDto> GetByIdAsync(int reservationId);
        Task CreateReservationAsync(DateTimeOffset checkIn, DateTimeOffset checkOut, int guestId, int roomId);
        Task CancelReservationAsync(int reservationId);
    }
}