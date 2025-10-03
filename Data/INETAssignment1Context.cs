using INETAssignment1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INETAssignment1.Data
{
    public class INETAssignment1Context : DbContext
    {
        public INETAssignment1Context(DbContextOptions<INETAssignment1Context> options)
            : base(options)
        {
        }

        public DbSet<INETAssignment1.Models.Concert> Concert { get; set; } = default!;
        public DbSet<INETAssignment1.Models.Band> Band { get; set; } = default!;
        public DbSet<INETAssignment1.Models.Genre> Genre { get; set; } = default!;
        public DbSet<INETAssignment1.Models.Location> Location { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Concert>()
                .HasMany(c => c.Genres)
                .WithMany(g => g.concerts);

            modelBuilder.Entity<Band>()
                .HasOne(b => b.genre)
                .WithMany(g => g.bands)
                .HasForeignKey(b => b.genreID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Concert>()
                .HasOne(c => c.headliningBand)
                .WithMany(b => b.concerts)
                .HasForeignKey(c => c.bandID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Concert>()
                .HasOne(c => c.concertLocation)
                .WithMany(l => l.concerts)
                .HasForeignKey(c => c.locationID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}