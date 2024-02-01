using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Domain;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.UpdateMatch
{
    public class UpdateMatchCommandHandler(
        IMatchesRepository matchesRepository,
        IUnitOfWork unitOfWork)
            : IRequestHandler<UpdateMatchCommand, ErrorOr<Success>>
    {
        private readonly IMatchesRepository _matchesRepository = matchesRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ErrorOr<Success>> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            var match = await _matchesRepository.GetByIdAsync(request.Id, cancellationToken);

            if (match == null)
            {
                return Error.NotFound(description: "Match not found");
            }

            match.Description = request.Description;
            match.MatchDate = request.MatchDate;
            match.MatchTime = request.MatchTime;
            match.TeamA = request.TeamA;
            match.TeamB = request.TeamB;
            match.Sport = request.Sport;

            await _matchesRepository.UpdateAsync(match);

            await _unitOfWork.CommitChangesAsync(cancellationToken);

            return Result.Success;
        }
    }
}
