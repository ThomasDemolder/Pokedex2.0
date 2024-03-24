using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Pokedex.Models;

namespace Pokedex.Util
{
    public class PokeClient
    {
        // Propriété publique HttpClient qui sera utilisée pour envoyer des requêtes HTTP.
        public HttpClient Client { get; set; }

        // Constructeur prenant un objet HttpClient comme paramètre.
        // Cet HttpClient est probablement configuré et fourni par l'injection de dépendances dans Blazor ou ASP.NET Core.
        public PokeClient(HttpClient client)
        {
            this.Client = client;
        }

        // Méthode asynchrone GetPokemon qui prend un identifiant de Pokémon (id) sous forme de chaîne de caractères.
        public async Task<Pokemon> GetPokemon(string id)
        {
            // Envoie une requête HTTP GET à la PokeAPI pour obtenir des données sur le Pokémon spécifié par son id.
            var response = await this.Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            // Lit le contenu de la réponse sous forme de chaîne de caractères.
            var content = await response.Content.ReadAsStringAsync();

            // Désérialise le contenu JSON en un objet Pokemon et le retourne.
            return JsonSerializer.Deserialize<Pokemon>(content);
        }
    }
}
