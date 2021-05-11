using System;

namespace GalaxyHotel.Core.Models
{
    public class PaymentMethod : BaseEntity
    {
        public string Alias { get; set; }
        public string CardNumber { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public Guest Guest { get; set; }
    }
}
