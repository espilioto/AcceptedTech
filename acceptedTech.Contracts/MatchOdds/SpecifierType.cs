using System.ComponentModel;
using System.Text.Json.Serialization;

namespace acceptedTech.Contracts.MatchOdds
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SpecifierType
    {
        None = 0,
        [Description("1")]
        One = 1,
        [Description("2")]
        Two = 2,
        [Description("X")]
        x = 3
    }
}
