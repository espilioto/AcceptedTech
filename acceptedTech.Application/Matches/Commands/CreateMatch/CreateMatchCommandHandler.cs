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
    }
}
