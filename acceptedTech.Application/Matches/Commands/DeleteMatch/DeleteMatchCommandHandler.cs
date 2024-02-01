using acceptedTech.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.DeleteMatch
{
    public class DeleteMatchCommandHandler(
        IMatchesRepository matchesRepository,
        IUnitOfWork unitOfWork)
            : IRequestHandler<DeleteMatchCommand, ErrorOr<Deleted>>
    {
        private readonly IMatchesRepository _matchesRepository = matchesRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ErrorOr<Deleted>> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
        {
            var match = await _matchesRepository.GetByIdAsync(request.Id, cancellationToken);

            if (match == null)
            {
                return Error.NotFound(description: "Match not found");
            }

            await _matchesRepository.RemoveAsync(match);

            await _unitOfWork.CommitChangesAsync(cancellationToken);

            return Result.Deleted;
        }
    }
}
