namespace GalaxyHotel.Core.Entities.GuestAggregate
{
    public class PaymentMethod : BaseEntity
    {
        public string Alias { get; private set; }
        public string CardId { get; private set; }
        public string Last4 { get; private set; }
    }
}