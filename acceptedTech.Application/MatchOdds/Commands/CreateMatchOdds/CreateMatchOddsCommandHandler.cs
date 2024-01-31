using acceptedTech.Application.Common.Interfaces;
using ErrorOr;

namespace acceptedTech.Application.MatchOdds.Commands.CreateMatchOdds
{
    public class CreateMatchOddsCommandHandler
    {
        private readonly IMatchOddsRepository _matchOddsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMatchOddsCommandHandler(IMatchOddsRepository matchOddsRepository, IUnitOfWork unitOfWork)
        {
            _matchOddsRepository = matchOddsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Domain.MatchOdds>> Handle(CreateMatchOddsCommand request, CancellationToken cancellationToken)
        {
            var matchOdds = new Domain.MatchOdds()
            {
                MatchId = request.MatchId,
                Odd = request.Odd,
                Specifier = request.Specifier
            };

            var result = await _matchOddsRepository.AddAsync(matchOdds, cancellationToken);
            await _unitOfWork.CommitChangesAsync();

            return result;
        }
    }
}
