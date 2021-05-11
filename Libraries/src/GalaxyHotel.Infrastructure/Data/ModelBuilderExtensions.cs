using GalaxyHotel.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GalaxyHotel.Infrastructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static void CreateSchema(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Guest)
                .WithMany(r => r.Reservations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(r => r.Reservations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guest>()
                .HasMany(g => g.Reservations)
                .WithOne(g => g.Guest)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guest>()
                .HasOne(g => g.Address)
                .WithOne(g => g.Guest)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guest>()
                .HasOne(g => g.PaymentMethod)
                .WithOne(g => g.Guest)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>()
                .HasOne(g => g.Guest)
                .WithOne(g => g.Address)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PaymentMethod>()
                .HasOne(g => g.Guest)
                .WithOne(g => g.PaymentMethod)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
