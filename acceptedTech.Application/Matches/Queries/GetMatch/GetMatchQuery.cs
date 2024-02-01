using acceptedTech.Domain;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.CreateMatch
{
    public record GetMatchQuery(int Id) : IRequest<ErrorOr<Match>>;
}
