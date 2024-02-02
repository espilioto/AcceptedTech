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

        public async Task<Match?> GetByIdAsync(int matchId, CancellationToken cancellationToken, bool includeOdds = false)
        {
            var query = _context.Matches.AsQueryable();

            if (includeOdds)
            {
                query = query.Include(x => x.MatchOdds);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == matchId, cancellationToken);
        }

        public async Task<List<Match>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Matches.ToListAsync(cancellationToken);
        }

        public async Task<bool> MatchExistsAsync(string teamA, string teamB, DateOnly matchDate, TimeOnly matchTime, CancellationToken cancellationToken)
        {
            return await _context.Matches
                .AnyAsync(x =>
                    x.TeamA == teamA &&
                    x.TeamB == teamB &&
                    x.MatchDate == matchDate &&
                    x.MatchTime == matchTime, cancellationToken);
        }

        public Task RemoveAsync(Match match)
        {
            _context.Remove(match);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Match match)
        {
            _context.Update(match);

            return Task.CompletedTask;
        }
    }
}
