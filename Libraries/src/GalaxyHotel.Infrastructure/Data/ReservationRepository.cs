using GalaxyHotel.Core.Models;

namespace GalaxyHotel.Infrastructure.Data
{
    public class ReservationRepository : Repository<Reservation>
    {
        public ReservationRepository(GalaxyHotelContext dbContext) :
            base(dbContext)
        {
        }
    }
}