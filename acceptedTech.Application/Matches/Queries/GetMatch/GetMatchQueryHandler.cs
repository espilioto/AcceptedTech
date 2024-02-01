using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Domain;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Queries.CreateMatch
{
    public class GetMatchQueryHandler(IMatchesRepository matchesRepository) : IRequestHandler<GetMatchQuery, ErrorOr<Match>>
    {
        private readonly IMatchesRepository _matchesRepository = matchesRepository;

        public async Task<ErrorOr<Match>> Handle(GetMatchQuery query, CancellationToken cancellationToken)
        {
            var match = await _matchesRepository.GetByIdAsync(query.MatchId, cancellationToken);

            if (match is null)
            {
                return Error.NotFound(description: "Match not found");
            }

            return match;
        }
    }
}
