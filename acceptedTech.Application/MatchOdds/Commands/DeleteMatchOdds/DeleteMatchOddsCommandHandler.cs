using acceptedTech.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Commands.DeleteMatchOdds
{
    public class DeleteMatchOddsCommandHandler(
        IMatchOddsRepository matchOddsRepository,
        IUnitOfWork unitOfWork)
            : IRequestHandler<DeleteMatchOddsCommand, ErrorOr<Deleted>>
    {
        private readonly IMatchOddsRepository _matchOddsRepository = matchOddsRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ErrorOr<Deleted>> Handle(DeleteMatchOddsCommand request, CancellationToken cancellationToken)
        {
            var matchOdds = await _matchOddsRepository.GetByIdAsync(request.MatchOddsId, cancellationToken);

            if (matchOdds is null)
            {
                return Error.NotFound(description: "Match not found");
            }

            await _matchOddsRepository.RemoveAsync(matchOdds);
            await _unitOfWork.CommitChangesAsync(cancellationToken);

            return Result.Deleted;
        }
    }
}