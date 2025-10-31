using hoopstatsapi.Domain.Entities;
using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Players;
using hoopstatsapi.Domain.Entities.Statistics;
using hoopstatsapi.Domain.Entities.Teams;
using Microsoft.EntityFrameworkCore;

namespace hoopstatsapi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatsSeason> PlayerStatsSeason { get; set; }
        public DbSet<PlayerGameStats> PlayerGameStats { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
