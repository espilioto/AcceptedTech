using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Domain;
using Microsoft.EntityFrameworkCore;

namespace acceptedTech.Infrastructure.Common.Persistence
{
    public class MatchesRepository : IMatchesRepository
    {
        private readonly AppDbContext _context;

        public MatchesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Match> AddAsync(Match match, CancellationToken cancellationToken)
        {
            await _context.Matches.AddAsync(match, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return match;
        }

        public async Task<Match?> GetByIdAsync(int matchId, CancellationToken cancellationToken)
        {
            return await _context.Matches.FirstOrDefaultAsync(x => x.Id == matchId, cancellationToken);
        }

        public Task RemoveAsync(Match match, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Match match, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
