namespace Pokedex.Util
{
    public static class PokeColor
    {
        public static string GetTypeColor(string type)
        {
            string color = type switch
            {
                "bug" => "#26de81",
                "dragon" => "#26de81",
                "electric" => "#26de81",
                "fairy" => "#26de81",
                "figthing" => "#26de81",
                "fire" => "#26de81",
                "flying" => "#26de81",
                "grass" => "#26de81",
                "ground" => "#26de81",
                "ghost" => "#26de81",
                "ice" => "#26de81",
                "normal" => "#26de81",
                "poison" => "#26de81",
                "psychic" => "#26de81",
                "rock" => "#26de81",
                "water" => "#0190ff",
                _ => "#26de81"
            };

            return color;
        }
    }
}
