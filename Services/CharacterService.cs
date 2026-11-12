using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using SearchNarutoAPI.Converters;
using SearchNarutoAPI.Models;

namespace SearchNarutoAPI.Services;

public sealed class CharacterService : ICharacterService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new FlexibleTextListConverter() }
    };

    private readonly HttpClient _httpClient;

    public CharacterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CharacterListResponse> GetPageAsync(
        int page,
        string? name = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<CharacterListResponse>(
                BuildUri(page, name),
                JsonOptions,
                cancellationToken);

            return response ?? new CharacterListResponse();
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return new CharacterListResponse();
        }
    }

    private static string BuildUri(int page, string? name)
    {
        var uri = $"characters?page={page}";

        return string.IsNullOrWhiteSpace(name)
            ? uri
            : $"{uri}&name={Uri.EscapeDataString(name.Trim())}";
    }
}
