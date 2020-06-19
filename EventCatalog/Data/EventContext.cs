using EventCatalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalog.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EventsCatalog> EventsCatalogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventsCatalog>(e =>
            {
                e.ToTable("EventsCatalogs");
                e.Property(e => e.Id)
                .IsRequired()
                .UseHiLo("event_hilo");

                e.Property(e => e.Name).IsRequired();
                e.Property(e => e.Description).IsRequired();
                e.Property(e => e.Price).IsRequired();
                e.Property(e => e.PictureUrl).IsRequired();
                e.Property(e => e.StartDate).IsRequired();
                e.Property(e => e.EndDate).IsRequired();

            //Foreign key relation 
            e.HasOne(e => e.EventCategory)
                .WithMany()
                .HasForeignKey(e => e.EventCategoryId);

                e.HasOne(e => e.EventLocation)
                .WithMany()
                .HasForeignKey(e => e.EventLocationId);

                e.HasOne(e => e.EventType)
                .WithMany()
                .HasForeignKey(e => e.EventTypeId);

            });

            modelBuilder.Entity<EventType>(e =>
            {
                e.ToTable("EventTypes");
                e.Property(t => t.Id)
                .IsRequired()
                .UseHiLo("event_type_hilo");

                e.Property(t => t.Type).IsRequired();
            });

            modelBuilder.Entity<EventCategory>(e =>
            {
                e.ToTable("EventCategories");
                e.Property(c => c.Id)
                .IsRequired()
                .UseHiLo("event_category_hilo");

                e.Property(c => c.Category).IsRequired();
            });

            modelBuilder.Entity<EventLocation>(e =>
            {
                e.ToTable("EventLocations");
                e.Property(l => l.Id).IsRequired()
                .UseHiLo("event_location_hilo");
                e.Property(l => l.UserId).IsRequired();
                e.Property(l => l.VenueName).HasMaxLength(100);
                e.Property(l => l.Address).IsRequired();
                e.Property(l => l.City).IsRequired().HasMaxLength(50);
                e.Property(l => l.State).IsRequired().HasMaxLength(100);
                e.Property(l => l.PostalCode).IsRequired();

            });
        }
    }
}

