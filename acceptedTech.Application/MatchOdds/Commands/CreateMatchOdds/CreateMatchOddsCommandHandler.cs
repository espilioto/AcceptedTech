using acceptedTech.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Commands.CreateMatchOdds
{
    public class CreateMatchOddsCommandHandler(
        IMatchesRepository matchesRepository,
        IMatchOddsRepository matchOddsRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateMatchOddsCommand, ErrorOr<Domain.MatchOdds>>
    {
        private readonly IMatchesRepository _matchesRepository = matchesRepository;
        private readonly IMatchOddsRepository _matchOddsRepository = matchOddsRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ErrorOr<Domain.MatchOdds>> Handle(CreateMatchOddsCommand request, CancellationToken cancellationToken)
        {
            var match = await _matchesRepository.GetByIdAsync(request.MatchId, cancellationToken, includeOdds: true);

            if (match is null)
            {
                return Error.NotFound(description: "Match not found");
            }

            if (match.MatchOdds.Count >= 3)
            {
                return Error.Validation(description: "Match already has three match odds");
            }

            if (match.MatchOdds.Any(odds => odds.Specifier == request.Specifier))
            {
                return Error.Validation(description: "A match odd with the same specifier already exists for this match");
            }

            var matchOdds = new Domain.MatchOdds()
            {
                MatchId = request.MatchId,
                Odd = request.Odd,
                Specifier = request.Specifier
            };

            var result = await _matchOddsRepository.AddAsync(matchOdds, cancellationToken);
            await _unitOfWork.CommitChangesAsync(cancellationToken);

            return result;
        }
    }
}