using acceptedTech.Domain.Common;

namespace acceptedTech.Domain
{
    public class MatchOdds : Entity
    {
        public required int MatchId { get; set; }
        public required string Specifier { get; set; }
        public required decimal Odd { get; set; }
    }
}
