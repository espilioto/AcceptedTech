using acceptedTech.Domain.Common;
using acceptedTech.Domain.Enums;

namespace acceptedTech.Domain
{
    public class Match : Entity
    {
        public string Description => $"{TeamA}-{TeamB}";
        public required DateOnly MatchDate { get; set; }
        public required TimeOnly MatchTime { get; set; }
        public required string TeamA { get; set; }
        public required string TeamB { get; set; }
        public required SportType Sport { get; set; }
    }
}
