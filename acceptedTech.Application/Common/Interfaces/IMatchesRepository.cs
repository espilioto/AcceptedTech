using acceptedTech.Domain;

namespace acceptedTech.Application.Common.Interfaces
{
    public interface IMatchesRepository
    {
        Task<Match> AddAsync(Match match, CancellationToken cancellationToken);
        Task<Match?> GetByIdAsync(int matchId, CancellationToken cancellationToken);
        Task RemoveAsync(Match match, CancellationToken cancellationToken);
        Task UpdateAsync(Match match, CancellationToken cancellationToken);
    }
}
