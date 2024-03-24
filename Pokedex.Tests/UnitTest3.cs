using Bunit;
using Moq;
using Pokedex.Models;
using Pokedex.Util;
using Pokedex.Pages;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using Xunit;



namespace Pokedex.Tests
{
    public class Home2Tests : TestContext
    {
        [Fact]
        public void Home2_Shows_PokemonList_After_Initialization()
        {
            // Arrange
            // Crée des mock objects pour PokeClient et FavoriteService, qui sont des dépendances du composant Home2.
            var mockPokeClient = new Moq.Mock<PokeClient>();
            var mockFavoriteService = new Moq.Mock<FavoriteService>();

            // Configure le mock de PokeClient pour retourner un objet Pokemon spécifique lorsqu'il est appelé.
            // Cela simule la réponse attendue sans effectuer de véritable appel HTTP.
            mockPokeClient.Setup(client => client.GetPokemon(It.IsAny<string>())).ReturnsAsync(new Pokemon { name = "TestPokemon" });

            // Injecte les mock objects dans le système de DI de Blazor pour qu'ils soient utilisés par le composant Home2.
            Services.AddSingleton<PokeClient>(mockPokeClient.Object);
            Services.AddSingleton<FavoriteService>(mockFavoriteService.Object);

            // Act
            // Rend le composant Home2, déclenchant son initialisation et la logique de chargement des Pokémon.
            var cut = RenderComponent<Home2>();

            // Assert
            // Vérifie que le composant affiche le nom du Pokémon "TestPokemon" qui a été configuré pour être retourné par le mock de PokeClient.
            // Cela confirme que le composant récupère et affiche les données des Pokémon comme attendu.
            Assert.Contains("TestPokemon", cut.Markup);
        }
    }

    public class FavoriteServiceTests
    {
        [Fact]
        public async Task AddToFavorites_ShouldAddPokemonIfNotAlreadyAFavorite()
        {
            // Arrange
            // Crée un mock object pour ILocalStorageService, qui est une dépendance du FavoriteService.
            var localStorageMock = new Mock<ILocalStorageService>();
            var favoriteService = new FavoriteService(localStorageMock.Object);
            var pokemon = new Pokemon { id = 1, name = "Bulbasaur" };
            var favoritesList = new List<Pokemon>();

            // Configure le mock de ILocalStorageService pour simuler une liste de favoris vide au départ,
            // et pour capturer les modifications apportées à cette liste lorsque le service est utilisé.
            localStorageMock.Setup(x => x.GetItemAsync<List<Pokemon>>("favorites", default))
                            .ReturnsAsync(favoritesList);
            localStorageMock.Setup(x => x.SetItemAsync("favorites", It.IsAny<List<Pokemon>>(), default))
                            .Callback<string, List<Pokemon>, System.Threading.CancellationToken>((key, value, token) =>
                            {
                                favoritesList.AddRange(value);
                            });

            // Act
            // Tente d'ajouter un Pokémon à la liste des favoris via le service.
            await favoriteService.AddToFavorites(pokemon);

            // Assert
            // Vérifie que le Pokémon spécifié est bien ajouté à la liste des favoris,
            // et que la méthode SetItemAsync de ILocalStorageService a été appelée une fois pour persister les favoris.
            Assert.Contains(pokemon, favoritesList);
            localStorageMock.Verify(x => x.SetItemAsync("favorites", It.IsAny<List<Pokemon>>(), default), Times.Once);
        }
    }
}