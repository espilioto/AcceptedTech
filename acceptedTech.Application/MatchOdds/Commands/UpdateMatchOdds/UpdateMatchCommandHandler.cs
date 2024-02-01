using acceptedTech.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Commands.UpdateMatchOdds
{
    public class UpdateMatchCommandHandler(
            IMatchOddsRepository matchOddsRepository,
            IUnitOfWork unitOfWork)
                : IRequestHandler<UpdateMatchOddsCommand, ErrorOr<Success>>
    {
        private readonly IMatchOddsRepository _matchOddsRepository = matchOddsRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ErrorOr<Success>> Handle(UpdateMatchOddsCommand request, CancellationToken cancellationToken)
        {
            var matchOdds = await _matchOddsRepository.GetByIdAsync(request.Id, cancellationToken);

            if (matchOdds is null)
            {
                return Error.NotFound(description: "Match odds not found");
            }

            matchOdds.MatchId = request.MatchId;
            matchOdds.Specifier = request.Specifier;
            matchOdds.Odd = request.Odd;

            await _matchOddsRepository.UpdateAsync(matchOdds);
            await _unitOfWork.CommitChangesAsync(cancellationToken);

            return Result.Success;
        }
    }
}
