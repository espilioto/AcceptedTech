using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Queries.ListMatchOdds
{
    public record ListMatchOddsQuery(): IRequest<ErrorOr<List<Domain.MatchOdds>>>;
}
