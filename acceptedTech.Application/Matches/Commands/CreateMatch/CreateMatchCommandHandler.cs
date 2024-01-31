using acceptedTech.Domain.Enums;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.CreateMatch
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, int>
    {
        public Task<int> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(int.MaxValue);
        }
    }
}
