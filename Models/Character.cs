namespace SearchNarutoAPI.Models;

public sealed class Character
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public List<string> Images { get; init; } = [];
    public List<string> Jutsu { get; init; } = [];
    public CharacterPersonal? Personal { get; init; }
    public CharacterRank? Rank { get; init; }

    public string? MainImage => Images.FirstOrDefault();
}
