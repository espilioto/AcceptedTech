using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Domain;
using Microsoft.EntityFrameworkCore;

namespace acceptedTech.Infrastructure.Common.Persistence
{
    public class MatchOddsRepository : IMatchOddsRepository
    {
        private readonly AppDbContext _context;

        public MatchOddsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MatchOdds> AddAsync(MatchOdds matchOdds, CancellationToken cancellationToken)
        {
            await _context.MatchOdds.AddAsync(matchOdds, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return matchOdds;
        }

        public async Task<MatchOdds?> GetByIdAsync(int matchOddsId, CancellationToken cancellationToken)
        {
            return await _context.MatchOdds.FirstOrDefaultAsync(x => x.Id == matchOddsId, cancellationToken);
        }

        public Task RemoveAsync(MatchOdds matchOdds, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MatchOdds matchOdds, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
