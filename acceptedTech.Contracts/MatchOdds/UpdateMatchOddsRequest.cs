namespace acceptedTech.Contracts.MatchOdds
{
    public record UpdateMatchOddsRequest(
        int MatchId,
        SpecifierType Specifier,
        decimal Odd);
}
