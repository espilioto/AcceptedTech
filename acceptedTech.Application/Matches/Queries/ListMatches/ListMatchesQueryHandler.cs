using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Domain;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Queries.CreateMatch
{
    public class ListMatchesQueryHandler(IMatchesRepository matchesRepository) : IRequestHandler<ListMatchesQuery, ErrorOr<List<Match>>>
    {
        private readonly IMatchesRepository _matchesRepository = matchesRepository;

        public async Task<ErrorOr<List<Match>>> Handle(ListMatchesQuery query, CancellationToken cancellationToken)
        {
            return await _matchesRepository.GetAllAsync(cancellationToken);
        }
    }
}
