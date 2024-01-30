using System.Text.Json.Serialization;

namespace acceptedTech.Contracts.Matches
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SportType
    {
        None,
        Football,
        Basketball
    }
}
