using Microsoft.EntityFrameworkCore;
using acceptedTech.Domain;
using acceptedTech.Application.Common.Interfaces;

namespace acceptedTech.Infrastructure.Common.Persistence
{
    public class AppDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
    {
        public DbSet<Match> Matches { get; set; } = null!;
        public DbSet<MatchOdds> MatchOdds { get; set; } = null!;

        public async Task CommitChangesAsync(CancellationToken cancellationToken)
        {
            await base.SaveChangesAsync(cancellationToken);
        }
    }
}