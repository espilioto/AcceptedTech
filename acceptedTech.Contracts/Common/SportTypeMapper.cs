using acceptedTech.Contracts.Matches;

namespace acceptedTech.Contracts.Common
{
    public static class SportTypeMapper
    {
        public static Domain.Enums.SportType ToDomainSportType(this Contracts.Matches.SportType sportType) =>
            sportType switch
            {
                SportType.None => Domain.Enums.SportType.None,
                SportType.Football => Domain.Enums.SportType.Football,
                SportType.Basketball => Domain.Enums.SportType.Basketball,
                _ => throw new ArgumentOutOfRangeException(nameof(sportType)),
            };

        public static Contracts.Matches.SportType ToContractSportType(this Domain.Enums.SportType sportType) =>
            sportType switch
            {
                Domain.Enums.SportType.None => Contracts.Matches.SportType.None,
                Domain.Enums.SportType.Football => Contracts.Matches.SportType.Football,
                Domain.Enums.SportType.Basketball => Contracts.Matches.SportType.Basketball,
                _ => throw new ArgumentOutOfRangeException(nameof(sportType)),
            };
    }
}
