using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Domain;
using acceptedTech.Domain.Enums;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.CreateMatch
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, ErrorOr<Match>>
    {
        private readonly IMatchesRepository _matchesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMatchCommandHandler(IMatchesRepository matchesRepository, IUnitOfWork unitOfWork)
        {
            _matchesRepository = matchesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Match>> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var match = new Match()
            {
                Description = request.Description,
                MatchDate = request.MatchDate,
                MatchTime = request.MatchTime,
                TeamA = request.TeamA,
                TeamB = request.TeamB,
                Sport = (SportType)request.Sport
            };
            
            var result = await _matchesRepository.AddAsync(match, cancellationToken);
            await _unitOfWork.CommitChangesAsync();

            return result;
        }
    }
}
