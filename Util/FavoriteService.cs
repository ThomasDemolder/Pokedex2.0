using Pokedex.Models;
using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Util
{
    public class FavoriteService
    {
        private readonly ILocalStorageService _localStorage;
        private const string StorageKey = "favorites";
        private List<Pokemon> favorites = new List<Pokemon>();

        public FavoriteService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task LoadFavoritesAsync()
        {
            var storedFavorites = await _localStorage.GetItemAsync<List<Pokemon>>(StorageKey);
            if (storedFavorites != null)
            {
                favorites = storedFavorites;
            }
        }

        public async Task AddToFavorites(Pokemon pokemon)
        {
            if (!favorites.Any(p => p.id == pokemon.id))
            {
                favorites.Add(pokemon);
                await _localStorage.SetItemAsync(StorageKey, favorites);
            }
        }

        public async Task RemoveFromFavorites(Pokemon pokemon)
        {
            favorites.RemoveAll(p => p.id == pokemon.id);
            await _localStorage.SetItemAsync(StorageKey, favorites);
        }

        public async Task UpdatePokemonName(int pokemonId, string newName)
        {
            var pokemon = favorites.FirstOrDefault(p => p.id == pokemonId);
            if (pokemon != null)
            {
                pokemon.CustomName = newName;
                await _localStorage.SetItemAsync(StorageKey, favorites);
            }
        }

        public List<Pokemon> GetFavorites()
        {
            return favorites;
        }
    }
}
