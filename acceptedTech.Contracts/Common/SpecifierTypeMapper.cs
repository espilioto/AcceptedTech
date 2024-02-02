using acceptedTech.Contracts.MatchOdds;

namespace acceptedTech.Contracts.Common
{
    public static class SpecifierTypeMapper
    {
        public static Domain.Enums.SpecifierType ToDomainSpecifierType(this SpecifierType sportType) =>
            sportType switch
            {
                SpecifierType.None => Domain.Enums.SpecifierType.None,
                SpecifierType.One => Domain.Enums.SpecifierType.One,
                SpecifierType.Two => Domain.Enums.SpecifierType.Two,
                SpecifierType.x => Domain.Enums.SpecifierType.x,
                _ => throw new ArgumentOutOfRangeException(nameof(sportType)),
            };

        public static SpecifierType ToContractSpecifierType(this Domain.Enums.SpecifierType sportType) =>
            sportType switch
            {
                Domain.Enums.SpecifierType.None => SpecifierType.None,
                Domain.Enums.SpecifierType.One => SpecifierType.One,
                Domain.Enums.SpecifierType.Two => SpecifierType.Two,
                Domain.Enums.SpecifierType.x => SpecifierType.x,
                _ => throw new ArgumentOutOfRangeException(nameof(sportType)),
            };
    }
}
