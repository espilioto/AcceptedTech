using acceptedTech.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Queries.GetMatchOddsForMatch
{
    public class GetMatchWithOddsForMatchQueryHandler(
        IMatchesRepository matchesRepository)
            : IRequestHandler<GetMatchWithOddsForMatchQuery, ErrorOr<Domain.Match>>
    {
        private readonly IMatchesRepository _matchesRepository = matchesRepository;

        public async Task<ErrorOr<Domain.Match>> Handle(GetMatchWithOddsForMatchQuery query, CancellationToken cancellationToken)
        {
            var match = await _matchesRepository.GetByIdAsync(query.MatchId, cancellationToken, includeOdds: true);

            if (match is null)
            {
                return Error.NotFound(description: "Match not found");
            }

            return match;
        }
    }
}
