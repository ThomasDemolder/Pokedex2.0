using Bunit;
using Pokedex.Pages;

namespace Pokedex.Tests
{
    public class CounterTests : TestContext
    {
        [Fact]
        public void CounterShouldIncrementWhenButtonIsClicked()
        {
            // Arrange: Créer une instance du composant Counter pour le test
            var cut = RenderComponent<Counter>();

            // Act: Simuler un clic sur le bouton pour incrémenter le compteur
            cut.Find("button").Click();

            // Assert: Vérifier que le compteur a bien été incrémenté de 1
            Assert.Equal("Current count: 1", cut.Find("p[role='status']").TextContent);
        }
    }
}