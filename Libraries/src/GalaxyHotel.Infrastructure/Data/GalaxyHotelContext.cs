using GalaxyHotel.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GalaxyHotel.Infrastructure.Data
{
    public class GalaxyHotelContext : DbContext
    {
        public GalaxyHotelContext(DbContextOptions<GalaxyHotelContext> options)
            : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.CreateSchema();
        }
    }
}