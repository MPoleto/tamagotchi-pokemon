using System.Text.Json;

namespace bichinho_virtual_pokemon_csharp
{
    public static class PokemonAPI
    {
        private static HashSet<Pokemon> VirtualPets = new();
        public static async Task<HashSet<Pokemon>> GetPokemonAsync(HttpClient client, string url)
        {
            var number = new Random();

            while (VirtualPets.Count <= 6)
            {
                var id = number.Next(1, 81);

                var json = await client.GetStringAsync($"{url}{id:N0}");
                
                var pokemon = JsonSerializer.Deserialize<Pokemon>(json);

                VirtualPets.Add(pokemon);
            }

            return VirtualPets;
        }
    }
}