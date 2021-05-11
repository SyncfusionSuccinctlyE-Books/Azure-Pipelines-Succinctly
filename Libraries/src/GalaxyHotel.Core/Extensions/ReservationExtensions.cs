using Ardalis.GuardClauses;
using GalaxyHotel.Core.Exceptions;
using GalaxyHotel.Core.Models;

namespace GalaxyHotel.Core.Extensions
{
    public static class ReservationExtensions
    {
        public static void NotExistingReservation(this IGuardClause guardClause, Reservation reservation)
        {
            if (reservation == null)
                throw new NotExistingReservationException();
        }
    }
}
