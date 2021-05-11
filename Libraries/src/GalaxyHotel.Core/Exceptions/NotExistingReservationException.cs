using System;

namespace GalaxyHotel.Core.Exceptions
{
    public class NotExistingReservationException : Exception
    {
        public NotExistingReservationException() 
            : base("Reservation was not found!")
        {

        }
    }
}
