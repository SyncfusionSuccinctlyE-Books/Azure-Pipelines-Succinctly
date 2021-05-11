using System.Collections.Generic;

namespace GalaxyHotel.Core.Models
{
    public class Guest : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
