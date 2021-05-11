using AutoMapper;
using GalaxyHotel.Core.Interfaces;
using GalaxyHotel.Core.Models;
using GalaxyHotel.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GalaxyHotel.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IAsyncRepository<Room> roomRepository;
        private readonly IMapper mapper;

        public RoomService(IAsyncRepository<Room> roomRepository, IMapper mapper)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetAll()
        {
            var rooms = await roomRepository.ListAllAsync();
            return mapper.Map<IEnumerable<RoomDto>>(rooms);
        }
    }
}
