namespace acceptedTech.Application.Common.Interfaces
{
    public interface IMatchOddsRepository
    {
        Task<Domain.MatchOdds> AddAsync(Domain.MatchOdds match, CancellationToken cancellationToken);
        Task<Domain.MatchOdds?> GetByIdAsync(int matchId, CancellationToken cancellationToken);
        Task<List<Domain.MatchOdds>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<Domain.MatchOdds>> GetMatchOddsForMatchAsync(int matchId, CancellationToken cancellationToken);
        Task RemoveAsync(Domain.MatchOdds match);
        Task UpdateAsync(Domain.MatchOdds match);

    }
}
