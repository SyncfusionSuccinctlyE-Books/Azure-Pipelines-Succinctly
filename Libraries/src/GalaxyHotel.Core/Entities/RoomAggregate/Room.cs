using Ardalis.GuardClauses;
using GalaxyHotel.Core.Interfaces;

namespace GalaxyHotel.Core.Entities.RoomAggregate
{
    public class Room : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public int Floor { get; private set; }
        public int RoomTypeId { get; private set; }
        public decimal PricePerNight { get; private set; }

        public Room() { }

        public Room(string name, int floor, int roomTypeId, decimal pricePerNight)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NegativeOrZero(floor, nameof(floor));
            Guard.Against.NegativeOrZero(roomTypeId, nameof(roomTypeId));
            Guard.Against.NegativeOrZero(pricePerNight, nameof(pricePerNight));

            Name = name;
            Floor = floor;
            RoomTypeId = roomTypeId;
            PricePerNight = pricePerNight;
        }
    }
}
