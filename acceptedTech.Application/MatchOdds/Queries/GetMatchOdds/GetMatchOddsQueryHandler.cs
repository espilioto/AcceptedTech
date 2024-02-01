using acceptedTech.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Queries.GetMatchOdds
{
    public class GetMatchOddsQueryHandler(IMatchOddsRepository matchOddsRepository) : IRequestHandler<GetMatchOddsQuery, ErrorOr<Domain.MatchOdds>>
    {
        private readonly IMatchOddsRepository _matchOddsRepository = matchOddsRepository;

        public async Task<ErrorOr<Domain.MatchOdds>> Handle(GetMatchOddsQuery query, CancellationToken cancellationToken)
        {
            var match = await _matchOddsRepository.GetByIdAsync(query.MatchOddsId, cancellationToken);

            if (match is null)
            {
                return Error.NotFound(description: "Match odds not found");
            }

            return match;
        }
    }
}
