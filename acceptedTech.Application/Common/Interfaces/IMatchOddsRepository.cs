using acceptedTech.Domain;

namespace acceptedTech.Application.Common.Interfaces
{
    public interface IMatchOddsRepository
    {
        Task AddAsync(MatchOdds matchOdds, CancellationToken cancellationToken);
        Task<MatchOdds?> GetByIdAsync(int matchOddsId, CancellationToken cancellationToken);
        Task RemoveAsync(MatchOdds matchOdds, CancellationToken cancellationToken);
        Task UpdateAsync(MatchOdds matchOdds, CancellationToken cancellationToken);
    }
}
