using GalaxyHotel.Dto;
using System.Collections.Generic;

namespace GalaxyHotel.HelpDesk.Models
{
    public class ReservationViewModel
    {
        public ReservationViewModel(IEnumerable<ReservationDto> reservations)
        {
            this.Reservations = reservations;
        }

        public IEnumerable<ReservationDto> Reservations { get; }
    }
}
