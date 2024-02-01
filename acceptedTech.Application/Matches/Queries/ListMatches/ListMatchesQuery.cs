using acceptedTech.Domain;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Queries.CreateMatch
{
    public record ListMatchesQuery() : IRequest<ErrorOr<List<Match>>>;
}
