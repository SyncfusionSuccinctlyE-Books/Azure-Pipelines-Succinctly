using System;

namespace GalaxyHotel.Dto
{
    public class ReservationDto
    {
        public DateTimeOffset CheckIn { get; set; }
        public DateTimeOffset CheckOut { get; set; }
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
