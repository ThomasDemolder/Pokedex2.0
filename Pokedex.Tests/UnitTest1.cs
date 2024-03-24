using Bunit;
using Pokedex.Pages;

namespace Pokedex.Tests
{
    public class CounterTests : TestContext
    {
        [Fact]
        public void CounterShouldIncrementWhenButtonIsClicked()
        {
            // Arrange: Cr�er une instance du composant Counter pour le test
            var cut = RenderComponent<Counter>();

            // Act: Simuler un clic sur le bouton pour incr�menter le compteur
            cut.Find("button").Click();

            // Assert: V�rifier que le compteur a bien �t� incr�ment� de 1
            Assert.Equal("Current count: 1", cut.Find("p[role='status']").TextContent);
        }
    }
}