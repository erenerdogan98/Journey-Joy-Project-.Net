using JourneyJoy.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JourneyJoy.DAL.Concrete
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, AppRole, int>(options)
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<GetContact> GetContacts { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        // For relations be better
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Identity tabloları için gerekli

            // Guide - Destination 
            modelBuilder.Entity<Guide>()
                .HasMany(h => h.Destinations)
                .WithOne(c => c.Guide)
                .HasForeignKey(c => c.GuideID)
                .OnDelete(DeleteBehavior.Restrict);

            // AppUser - Reservation
            modelBuilder.Entity<AppUser>()
              .HasMany(h => h.Reservations)
              .WithOne(c => c.AppUser)
              .HasForeignKey(c => c.AppUserId)
              .OnDelete(DeleteBehavior.Restrict);

            // AppUser - Commment
            modelBuilder.Entity<AppUser>()
              .HasMany(h => h.Comments)
              .WithOne(c => c.AppUser)
              .HasForeignKey(c => c.AppUserId)
              .OnDelete(DeleteBehavior.Restrict);

            // Destination - Reservation
            modelBuilder.Entity<Destination>()
              .HasMany(h => h.Reservations)
              .WithOne(c => c.Destination)
              .HasForeignKey(c => c.DestinationId)
              .OnDelete(DeleteBehavior.Restrict);

            // Destination - Comment
            modelBuilder.Entity<Destination>()
              .HasMany(h => h.Comments)
              .WithOne(c => c.Destination)
              .HasForeignKey(c => c.DestinationId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
