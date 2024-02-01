using acceptedTech.Domain;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.CreateMatch
{
    public record ListMatchesQuery() : IRequest<ErrorOr<List<Match>>>;
}
