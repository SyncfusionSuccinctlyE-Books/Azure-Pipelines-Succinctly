using GalaxyHotel.Dto;
using System.Collections.Generic;

namespace GalaxyHotel.Website.Models
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
