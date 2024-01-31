using Microsoft.EntityFrameworkCore;
using acceptedTech.Domain;
using acceptedTech.Application.Common.Interfaces;

namespace acceptedTech.Infrastructure.Common.Persistence
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Match> Matches { get; set; } = null!;
        public DbSet<MatchOdds> MatchOdds { get; set; } = null!;

        public AppDbContext(DbContextOptions options) : base(options) { }

        public async Task CommitChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}