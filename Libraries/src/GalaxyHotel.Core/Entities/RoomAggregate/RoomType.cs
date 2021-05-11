using Ardalis.GuardClauses;

namespace GalaxyHotel.Core.Entities.RoomAggregate
{
    public class RoomType : BaseEntity
    {
        public string Type { get; private set; }

        public RoomType()
        {
            
        }

        public RoomType(string type)
        {
            Guard.Against.NullOrEmpty(type, nameof(type));

            Type = type;
        }
    }
}
