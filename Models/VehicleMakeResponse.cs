using System.Text.Json.Serialization;

namespace PokedexMaui.Models;

public class VehicleMakeResponse
{
    [JsonPropertyName("Count")]
    public int Count { get; set; }

    [JsonPropertyName("Message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("SearchCriteria")]
    public string? SearchCriteria { get; set; }

    [JsonPropertyName("Results")]
    public List<VehicleMake> Results { get; set; } = [];
}

public class VehicleMake
{
    [JsonPropertyName("Make_ID")]
    public int MakeId { get; set; }

    [JsonPropertyName("Make_Name")]
    public string MakeName { get; set; } = string.Empty;
}
