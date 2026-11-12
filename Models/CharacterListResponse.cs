namespace SearchNarutoAPI.Models;

public sealed class CharacterListResponse
{
    public List<Character> Characters { get; init; } = [];
    public int CurrentPage { get; init; } = 1;
    public int PageSize { get; init; }
    public int Total { get; init; }

    public int TotalPages => PageSize > 0 ? (int)Math.Ceiling(Total / (double)PageSize) : 0;
}
