using GalaxyHotel.Dto;
using System.Collections.Generic;

namespace GalaxyHotel.HelpDesk.Models
{
    public class RoomViewModel
    {
        public RoomViewModel(IEnumerable<RoomDto> rooms)
        {
            this.Rooms = rooms;
        }

        public IEnumerable<RoomDto> Rooms { get; }
    }
}
