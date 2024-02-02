using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Domain;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.CreateMatch
{
    public class CreateMatchCommandHandler(
        IMatchesRepository matchesRepository,
        IUnitOfWork unitOfWork)
            : IRequestHandler<CreateMatchCommand, ErrorOr<Match>>
    {
        private readonly IMatchesRepository _matchesRepository = matchesRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ErrorOr<Match>> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            if (await MatchExists(request.TeamA, request.TeamB, request.MatchDate, request.MatchTime, cancellationToken))
            {
                return Error.Validation(description: "A match with the same teams and date/time already exists");
            }

            var match = new Match()
            {
                Description = request.Description,
                MatchDate = request.MatchDate,
                MatchTime = request.MatchTime,
                TeamA = request.TeamA,
                TeamB = request.TeamB,
                Sport = request.Sport
            };

            var result = await _matchesRepository.AddAsync(match, cancellationToken);
            await _unitOfWork.CommitChangesAsync(cancellationToken);

            return result;
        }

        private async Task<bool> MatchExists(string teamA, string teamB, DateOnly matchDate, TimeOnly matchTime, CancellationToken cancellationToken)
        {
            var matchExists = await _matchesRepository.MatchExistsAsync(teamA, teamB, matchDate, matchTime, cancellationToken);
            return matchExists;
        }
    }
}
