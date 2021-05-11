using Ardalis.GuardClauses;
using GalaxyHotel.Core.Interfaces;
using System;

namespace GalaxyHotel.Core.Entities.ReservationAggregate
{
    public class Reservation : BaseEntity, IAggregateRoot
    {
        public DateTimeOffset CheckIn { get; private set; }
        public DateTimeOffset CheckOut { get; private set; }
        public int GuestId { get; private set; }
        public int RoomId { get; private set; }
        public decimal PricePerNight { get; private set; }

        public Reservation() { }

        public Reservation(DateTimeOffset checkIn, DateTimeOffset checkOut, int guestId, int roomId, decimal pricePerNight)
        {
            Guard.Against.NegativeOrZero(guestId, nameof(guestId));
            Guard.Against.NegativeOrZero(roomId, nameof(roomId));
            Guard.Against.NegativeOrZero(pricePerNight, nameof(pricePerNight));

            CheckIn = checkIn;
            CheckOut = checkOut;
            GuestId = guestId;
            RoomId = roomId;
            PricePerNight = pricePerNight;
        }

        public void UpdatePricePerNight(decimal pricePerNight)
        {
            PricePerNight = pricePerNight;
        }

        public void UpdateCheckOutDate(DateTimeOffset newCheckOutDate)
        {
            CheckOut = newCheckOutDate;
        }

        public decimal TotalPrice()
        {
            return PricePerNight * (decimal)(CheckOut.Subtract(CheckIn).TotalDays);
        }
    }
}
