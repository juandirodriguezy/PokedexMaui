using System.Net;
using System.Net.Http.Json;
using PokedexMaui.Models;

namespace PokedexMaui.Services;

public class VehicleApiService
{
    private readonly HttpClient _httpClient;

    public VehicleApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<VehicleMake>> GetAllMakesAsync(CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response = await _httpClient.GetAsync("vehicles/GetAllMakes?format=json", cancellationToken);
        
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<VehicleMakeResponse>(cancellationToken: cancellationToken);
        
        return content?.Results ?? new List<VehicleMake>();
    }
}
