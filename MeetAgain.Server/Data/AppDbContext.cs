using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MeetAgain.Shared.Models;

namespace MeetAgain.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // --- DbSets ---
        public DbSet<Friend> Friends => Set<Friend>();
        public DbSet<FriendGroup> FriendGroups => Set<FriendGroup>();
        public DbSet<Meetup> Meetups => Set<Meetup>();
        public DbSet<Availability> Availabilities => Set<Availability>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ignore EF “Pending model changes” warning (safe in dev)
            optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==============================
            // FRIEND CONFIGURATION
            // ==============================
            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(200);

                entity.Property(e => e.GroupIds)
                    .HasConversion(
                        v => string.Join(',', v ?? new List<string>()),
                        v => (v ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                    .Metadata.SetValueComparer(ListComparer<string>());
            });

            // ==============================
            // FRIENDGROUP CONFIGURATION
            // ==============================
            modelBuilder.Entity<FriendGroup>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                entity.Property(e => e.MemberIds)
                    .HasConversion(
                        v => string.Join(',', v ?? new List<string>()),
                        v => (v ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                    .Metadata.SetValueComparer(ListComparer<string>());
            });

            // ==============================
            // MEETUP CONFIGURATION
            // ==============================
            modelBuilder.Entity<Meetup>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Location).IsRequired().HasMaxLength(300);

                entity.Property(e => e.ParticipantIds)
                    .HasConversion(
                        v => string.Join(',', v ?? new List<string>()),
                        v => (v ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                    .Metadata.SetValueComparer(ListComparer<string>());

                entity.Property(e => e.ProposedDates)
                    .HasConversion(
                        v => string.Join('|', (v ?? new List<DateTime>()).Select(d => d.ToString("O"))),
                        v => (v ?? "").Split('|', StringSplitOptions.RemoveEmptyEntries)
                            .Select(DateTime.Parse).ToList()
                    )
                    .Metadata.SetValueComparer(ListComparer<DateTime>());
            });

            // ==============================
            // AVAILABILITY CONFIGURATION
            // ==============================
            modelBuilder.Entity<Availability>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.MeetupId);
                entity.HasIndex(e => e.FriendId);
            });

            // ==============================
            // SEED DATA
            // ==============================
            SeedData(modelBuilder);
        }

        // --- ✅ Expression-safe ValueComparer ---
        private static ValueComparer<List<T>> ListComparer<T>() =>
            new ValueComparer<List<T>>(
                (c1, c2) =>
                    (c1 == null && c2 == null) ||
                    (c1 != null && c2 != null && c1.SequenceEqual(c2)),
                c => c == null
                    ? 0
                    : c.Aggregate(17, (a, v) => HashCode.Combine(a, v == null ? 0 : v.GetHashCode())),
                c => c == null ? new List<T>() : new List<T>(c)
            );

        // --- Initial Data Seeding ---
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(
                new Friend { Id = "1", Name = "Alice Johnson", Email = "alice@example.com", Avatar = "AJ", CreatedAt = DateTime.UtcNow },
                new Friend { Id = "2", Name = "Bob Smith", Email = "bob@example.com", Avatar = "BS", CreatedAt = DateTime.UtcNow },
                new Friend { Id = "3", Name = "Carol White", Email = "carol@example.com", Avatar = "CW", CreatedAt = DateTime.UtcNow },
                new Friend { Id = "4", Name = "David Brown", Email = "david@example.com", Avatar = "DB", CreatedAt = DateTime.UtcNow },
                new Friend { Id = "5", Name = "Emma Davis", Email = "emma@example.com", Avatar = "ED", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<FriendGroup>().HasData(
                new FriendGroup
                {
                    Id = "g1",
                    Name = "Work Team",
                    Description = "Office colleagues",
                    Color = "#6366f1",
                    CreatedAt = DateTime.UtcNow
                },
                new FriendGroup
                {
                    Id = "g2",
                    Name = "College Friends",
                    Description = "University buddies",
                    Color = "#10b981",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
