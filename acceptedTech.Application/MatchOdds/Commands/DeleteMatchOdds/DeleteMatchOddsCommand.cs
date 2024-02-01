using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Commands.DeleteMatchOdds
{
    public record DeleteMatchOddsCommand(int MatchOddsId) : IRequest<ErrorOr<Deleted>>;
}
