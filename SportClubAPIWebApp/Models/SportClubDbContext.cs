// Data/ApplicationDbContext.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportClubAPIWebApp.Models;
using System;

public class SportClubDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbSet<ClientProfile> ClientProfiles { get; set; } = null!;
    public DbSet<TrainerProfile> TrainerProfiles { get; set; } = null!;
    public DbSet<ActivityType> ActivityTypes { get; set; } = null!;
    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<Enrollment> Enrollments { get; set; } = null!;

    public SportClubDbContext(DbContextOptions<SportClubDbContext> opts)
        : base(opts) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Альтернативні таблиці IdentityRole<Guid> тощо вже налаштовані в базі.

        // 1–1 між User ↔ ClientProfile
        builder.Entity<ApplicationUser>()
            .HasOne(u => u.ClientProfile)
            .WithOne(p => p.User)
            .HasForeignKey<ClientProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // 1–1 між User ↔ TrainerProfile
        builder.Entity<ApplicationUser>()
            .HasOne(u => u.TrainerProfile)
            .WithOne(p => p.User)
            .HasForeignKey<TrainerProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // 1–M: ClientProfile → Subscriptions, Enrollments
        builder.Entity<ClientProfile>()
            .HasMany(c => c.Subscriptions)
            .WithOne(s => s.Client)
            .HasForeignKey(s => s.ClientId);

        builder.Entity<ClientProfile>()
            .HasMany(c => c.Enrollments)
            .WithOne(e => e.Client)
            .HasForeignKey(e => e.ClientId);

        // 1–M: TrainerProfile → Sessions
        builder.Entity<TrainerProfile>()
            .HasMany(t => t.Sessions)
            .WithOne(s => s.Trainer)
            .HasForeignKey(s => s.TrainerId);
    }
}
