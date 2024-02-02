using acceptedTech.Domain.Common;
using acceptedTech.Domain.Enums;

namespace acceptedTech.Domain
{
    public class MatchOdds : Entity
    {
        public required int MatchId { get; set; }
        public required SpecifierType Specifier { get; set; }
        public required decimal Odd { get; set; }
    }
}
