using acceptedTech.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Queries.ListMatchOdds
{
    public class ListMatchOddsQueryHandler(IMatchOddsRepository matchOddsRepository) : IRequestHandler<ListMatchOddsQuery, ErrorOr<List<Domain.MatchOdds>>>
    {
        private readonly IMatchOddsRepository _matchOddsRepository = matchOddsRepository;

        public async Task<ErrorOr<List<Domain.MatchOdds>>> Handle(ListMatchOddsQuery query, CancellationToken cancellationToken)
        {
            return await _matchOddsRepository.GetAllAsync(cancellationToken);
        }
    }
}
