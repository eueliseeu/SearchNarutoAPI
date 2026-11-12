using SearchNarutoAPI.Models;

namespace SearchNarutoAPI.Services;

public interface ICharacterService
{
    Task<CharacterListResponse> GetPageAsync(int page, string? name = null, CancellationToken cancellationToken = default);
}
