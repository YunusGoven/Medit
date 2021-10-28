using Medit1.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medit1.Models
{
    public class Medit1DbContext : IdentityDbContext
    {
        public Medit1DbContext(DbContextOptions<Medit1DbContext>opt):base(opt){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CruisePort>().HasKey(c => new { c.CruiseId, c.PortId });
            modelBuilder.Entity<CruiseCommodite>().HasKey(c => new {c.CruiseId, c.CommoditeId});
            modelBuilder.Entity<ParticipantReservation>().HasKey(u => new {u.ParticipantId, u.ReservationId});

            modelBuilder.ApplyConfiguration(new BoatConfiguration());
            modelBuilder.ApplyConfiguration(new PortConfiguration());
            modelBuilder.ApplyConfiguration(new TypeCruiseConfiguration());
            modelBuilder.ApplyConfiguration(new CommoditeConfiguration());
            modelBuilder.ApplyConfiguration(new CruisesConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationParticipantConfiguration());
        }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<Cruise> Cruises { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<TypeCruise> TypeCruises { get; set; }
        public DbSet<Image>Image { get; set; }
        public DbSet<Commodite>Commodites { get; set; }
        public DbSet<CruisePort>CruisePorts { get; set; }
        public DbSet<CruiseCommodite> CruiseCommodites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<ParticipantReservation> ParticipantReservations { get; set; }
    }
}
