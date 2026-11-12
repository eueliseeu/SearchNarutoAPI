using System.Text.Json;
using Microsoft.AspNetCore.Components;
using SearchNarutoAPI.Models;
using SearchNarutoAPI.Services;

namespace SearchNarutoAPI.Pages;

public partial class Home
{
    [Inject]
    private ICharacterService CharacterService { get; set; } = default!;

    private IReadOnlyList<Character> _characters = [];
    private Character? _character;
    private int? _selectedId;
    private string _searchTerm = string.Empty;
    private int _currentPage = 1;
    private int _totalPages;
    private string? _errorMessage;
    private bool _isLoading = true;

    protected override async Task OnInitializedAsync()
    {
        await LoadPageAsync(1);
    }

    private async Task SearchAsync()
    {
        await LoadPageAsync(1);
    }

    private async Task PreviousPageAsync()
    {
        await LoadPageAsync(_currentPage - 1);
    }

    private async Task NextPageAsync()
    {
        await LoadPageAsync(_currentPage + 1);
    }

    private async Task LoadPageAsync(int page)
    {
        _isLoading = true;
        _errorMessage = null;

        try
        {
            var response = await CharacterService.GetPageAsync(page, _searchTerm);

            _characters = response.Characters;
            _currentPage = page;
            _totalPages = response.TotalPages;
            _character = _characters.FirstOrDefault();
            _selectedId = _character?.Id;
        }
        catch (Exception exception) when (exception is HttpRequestException or JsonException)
        {
            _errorMessage = "Não foi possível carregar os personagens. Tente novamente em instantes.";
        }
        finally
        {
            _isLoading = false;
        }
    }

    private void SelectCharacter()
    {
        _character = _characters.FirstOrDefault(character => character.Id == _selectedId);
    }

    private static string Describe(IEnumerable<string>? values)
    {
        return values is not null && values.Any()
            ? string.Join(", ", values)
            : "Não informado";
    }
}
