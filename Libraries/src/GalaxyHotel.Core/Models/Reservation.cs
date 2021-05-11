using System;

namespace GalaxyHotel.Core.Models
{
    public class Reservation : BaseEntity
    {
        public DateTimeOffset CheckIn { get; set; }
        public DateTimeOffset CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
