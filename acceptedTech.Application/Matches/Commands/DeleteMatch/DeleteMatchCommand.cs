using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.DeleteMatch
{
    public record DeleteMatchCommand(int Id) : IRequest<ErrorOr<Deleted>>;
}
