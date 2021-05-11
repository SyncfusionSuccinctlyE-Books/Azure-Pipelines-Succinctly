using System.Collections;
using System.Collections.Generic;

namespace GalaxyHotel.Core.Models
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public int Floor { get; set; }
        public decimal PricePerNight { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}