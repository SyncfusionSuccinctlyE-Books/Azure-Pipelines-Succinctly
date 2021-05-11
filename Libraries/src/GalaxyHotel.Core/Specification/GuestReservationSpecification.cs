using GalaxyHotel.Core.Helpers.Query;
using GalaxyHotel.Core.Models;

namespace GalaxyHotel.Core.Specification
{
    public class GuestReservationSpecification : BaseSpecification<Reservation>
    {
        public GuestReservationSpecification(int guestId)
            : base(o => o.GuestId == guestId)
        {
            AddIncludes(query => query.Include(o => o.Guest).Include(o => o.Room));
        }
    }
}
