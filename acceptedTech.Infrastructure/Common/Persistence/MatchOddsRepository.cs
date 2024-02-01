using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Domain;
using Microsoft.EntityFrameworkCore;

namespace acceptedTech.Infrastructure.Common.Persistence
{
    public class MatchOddsRepository(AppDbContext appDbContext) : IMatchOddsRepository
    {
        private readonly AppDbContext _context = appDbContext;

        public async Task<MatchOdds> AddAsync(MatchOdds match, CancellationToken cancellationToken)
        {
            var result = await _context.MatchOdds.AddAsync(match, cancellationToken);

            return result.Entity;
        }

        public async Task<MatchOdds?> GetByIdAsync(int matchId, CancellationToken cancellationToken)
        {
            return await _context.MatchOdds.FirstOrDefaultAsync(x => x.Id == matchId, cancellationToken);
        }

        public async Task<List<MatchOdds>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.MatchOdds.ToListAsync(cancellationToken);
        }

        public async Task<MatchOdds?> GetByIdAsync(int matchOddsId, CancellationToken cancellationToken)
        {
            return await _context.MatchOdds.FirstOrDefaultAsync(x => x.Id == matchOddsId, cancellationToken);
        }

        public Task RemoveAsync(MatchOdds match)
        {
            _context.Remove(match);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(MatchOdds match)
        {
            _context.Update(match);

            return Task.CompletedTask;
        }
    }
}
