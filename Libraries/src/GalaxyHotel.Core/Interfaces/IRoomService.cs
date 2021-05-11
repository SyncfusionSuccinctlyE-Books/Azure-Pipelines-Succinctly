using GalaxyHotel.Core.Models;
using GalaxyHotel.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GalaxyHotel.Core.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAll();
    }
}