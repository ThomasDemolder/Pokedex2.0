using Bunit;
using Pokedex.Pages;

namespace Pokedex.Tests
{
    public class PokemonAleatoireTests : TestContext
    {
        [Fact]
        public void PokemonAleatoire_ShouldChangeOnEachClick()
        {
            // Arrange: initialiser le composant et le bouton pour le test
            var cut = RenderComponent<PokemonAleatoire>();
            var button = cut.Find("button");

            string firstPokemon, secondPokemon;

            // Act: Cliquer sur le bouton pour obtenir le premier Pokémon
            button.Click();
            firstPokemon = cut.Find("p").TextContent;

            // Simuler un certain nombre de clics pour s'assurer que le Pokémon change
            do
            {
                button.Click();
                secondPokemon = cut.Find("p").TextContent;
            }
            while (secondPokemon == firstPokemon); // Répéter si le même Pokémon est sélectionné (peu probable avec une grande liste)

            // Assert: Vérifier que le Pokémon affiché change après les clics
            Assert.NotEqual(firstPokemon, secondPokemon);
        }
    }
}
