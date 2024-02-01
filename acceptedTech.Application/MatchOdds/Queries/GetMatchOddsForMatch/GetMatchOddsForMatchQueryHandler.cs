using acceptedTech.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Queries.GetMatchOddsForMatch
{
    public class GetMatchOddsForMatchQueryHandler(
        IMatchesRepository matchesRepository,
        IMatchOddsRepository matchOddsRepository)
            : IRequestHandler<GetMatchOddsForMatchQuery, ErrorOr<List<Domain.MatchOdds>>>
    {
        private readonly IMatchesRepository _matchesRepository = matchesRepository;
        private readonly IMatchOddsRepository _matchOddsRepository = matchOddsRepository;

        public async Task<ErrorOr<List<Domain.MatchOdds>>> Handle(GetMatchOddsForMatchQuery query, CancellationToken cancellationToken)
        {
            var match = await _matchesRepository.GetByIdAsync(query.MatchId, cancellationToken);

            if (match is null)
            {
                return Error.NotFound(description: "Match not found");
            }

            var matchOdds = await _matchOddsRepository.GetMatchOddsForMatchAsync(query.MatchId, cancellationToken);

            return matchOdds;
        }
    }
}
