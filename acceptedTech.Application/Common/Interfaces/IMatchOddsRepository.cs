namespace acceptedTech.Application.Common.Interfaces
{
    public interface IMatchOddsRepository
    {
        Task<Domain.MatchOdds> AddAsync(Domain.MatchOdds matchOdds, CancellationToken cancellationToken);
        Task<Domain.MatchOdds?> GetByIdAsync(int matchOddsId, CancellationToken cancellationToken);
        Task RemoveAsync(Domain.MatchOdds matchOdds, CancellationToken cancellationToken);
        Task UpdateAsync(Domain.MatchOdds matchOdds, CancellationToken cancellationToken);
    }
}
