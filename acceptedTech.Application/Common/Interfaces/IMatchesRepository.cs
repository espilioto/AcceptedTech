using acceptedTech.Domain;

namespace acceptedTech.Application.Common.Interfaces
{
    public interface IMatchesRepository
    {
        Task<Match> AddAsync(Match match, CancellationToken cancellationToken);
        Task<Match?> GetByIdAsync(int matchId, CancellationToken cancellationToken, bool includeOdds = false);
        Task<List<Match>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> MatchExistsAsync(string teamA, string teamB, DateOnly matchDate, TimeOnly matchTime, CancellationToken cancellationToken);
        Task RemoveAsync(Match match);
        Task UpdateAsync(Match match);
    }
}
