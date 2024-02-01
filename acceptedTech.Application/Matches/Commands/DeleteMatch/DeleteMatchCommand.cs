using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.CreateMatch
{
    public record DeleteMatchCommand(int Id) : IRequest<ErrorOr<Deleted>>;
}
