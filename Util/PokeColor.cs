namespace Pokedex.Util
{
    public static class PokeColor
    {
        public static string GetTypeColor(string type)
        {
            string color = type switch
            {
                "bug" => "#A8B820",
                "dragon" => "#7038F8",
                "electric" => "#F8D030",
                "fairy" => "#EE99AC",
                "fighting" => "#C03028",
                "fire" => "#F08030",
                "flying" => "#A890F0",
                "grass" => "#78C850",
                "ground" => "#E0C068",
                "ghost" => "#705898",
                "ice" => "#98D8D8",
                "normal" => "#A8A878",
                "poison" => "#A040A0",
                "psychic" => "#F85888",
                "rock" => "#B8A038",
                "water" => "#6890F0",
                _ => "#68A090"
            };

            return color;
        }
    }
}
