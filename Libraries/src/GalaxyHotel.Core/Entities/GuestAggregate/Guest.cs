using Ardalis.GuardClauses;
using GalaxyHotel.Core.Interfaces;
using System.Collections.Generic;

namespace GalaxyHotel.Core.Entities.GuestAggregate
{
    public class Guest : BaseEntity, IAggregateRoot
    {
        private List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
        public IEnumerable<PaymentMethod> PaymentMethods => paymentMethods.AsReadOnly();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }

        public Guest()
        {

        }

        public Guest(string firstName, string lastName, Address address)
        {
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.Null(address, nameof(address));

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }
    }
}
