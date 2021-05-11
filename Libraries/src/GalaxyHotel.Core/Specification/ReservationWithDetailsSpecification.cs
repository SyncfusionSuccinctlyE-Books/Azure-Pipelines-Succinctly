using GalaxyHotel.Core.Helpers.Query;
using GalaxyHotel.Core.Models;

namespace GalaxyHotel.Core.Specification
{
    public class ReservationWithDetailsSpecification : BaseSpecification<Reservation>
    {
        public ReservationWithDetailsSpecification()
            : base()
        {
            AddIncludes(query => query
                .Include(o => o.Room)
                .Include(o => o.Guest));
        }
    }
}
