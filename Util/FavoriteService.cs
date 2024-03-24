using Pokedex.Models;
using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Util
{
    public class FavoriteService
    {
        // Déclaration d'un champ privé pour le service de stockage local et une constante pour la clé de stockage.
        private readonly ILocalStorageService _localStorage;
        private const string StorageKey = "favorites";

        // Liste pour garder en mémoire les Pokémon favoris.
        private List<Pokemon> favorites = new List<Pokemon>();

        // Constructeur qui initialise le service de stockage local.
        public FavoriteService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        // Charge les favoris depuis le stockage local et les assigne à la liste de favoris en mémoire.
        public async Task LoadFavoritesAsync()
        {
            var storedFavorites = await _localStorage.GetItemAsync<List<Pokemon>>(StorageKey);
            if (storedFavorites != null)
            {
                favorites = storedFavorites;
            }
        }

        // Ajoute un Pokémon à la liste de favoris si ce n'est pas déjà fait, et met à jour le stockage local.
        public async Task AddToFavorites(Pokemon pokemon)
        {
            if (!favorites.Any(p => p.id == pokemon.id))
            {
                favorites.Add(pokemon);
                await _localStorage.SetItemAsync(StorageKey, favorites);
            }
        }

        // Supprime un Pokémon de la liste des favoris et met à jour le stockage local.
        public async Task RemoveFromFavorites(Pokemon pokemon)
        {
            favorites.RemoveAll(p => p.id == pokemon.id);
            await _localStorage.SetItemAsync(StorageKey, favorites);
        }

        // Met à jour le nom personnalisé d'un Pokémon favori et met à jour le stockage local.
        public async Task UpdatePokemonName(int pokemonId, string newName)
        {
            var pokemon = favorites.FirstOrDefault(p => p.id == pokemonId);
            if (pokemon != null)
            {
                pokemon.CustomName = newName;
                await _localStorage.SetItemAsync(StorageKey, favorites);
            }
        }

        // Retourne la liste des Pokémon favoris en mémoire.
        public List<Pokemon> GetFavorites()
        {
            return favorites;
        }
    }
}
