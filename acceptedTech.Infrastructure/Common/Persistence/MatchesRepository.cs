using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Domain;
using Microsoft.EntityFrameworkCore;

namespace acceptedTech.Infrastructure.Common.Persistence
{
    public class MatchesRepository(AppDbContext context) : IMatchesRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Match> AddAsync(Match match, CancellationToken cancellationToken)
        {
            var result = await _context.Matches.AddAsync(match, cancellationToken);

            return result.Entity;
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
