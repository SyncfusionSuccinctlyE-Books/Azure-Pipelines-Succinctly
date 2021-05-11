using AutoMapper;
using GalaxyHotel.Core.Models;
using GalaxyHotel.Dto;

namespace GalaxyHotel.Core.Mapping
{
    public class GalaxyHotelProfile : Profile
    {
        public GalaxyHotelProfile()
        {
            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.RoomName, opts => opts.MapFrom(src => src.Room.Name))
                .ForMember(dest => dest.GuestName, opts => opts.MapFrom(src => $"{src.Guest.FirstName} {src.Guest.LastName}"));

            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Floor, opts => opts.MapFrom(src => src.Floor))
                .ForMember(dest => dest.PricePerNight, opts => opts.MapFrom(src => src.PricePerNight));
        }
    }
}
