using System.Text.Json;

namespace bichinho_virtual_pokemon_csharp
{
    public static class PokemonAPI
    {
        public static async Task<List<Pokemon>> GetPokemonAsync(HttpClient client, string url, List<Pokemon> list)
        {
            var number = new Random();

            for (int i = 1; i < 6; i++)
            {
                var id = number.Next(1, 81);

                var json = await client.GetStringAsync($"{url}{id:N0}");
                
                var pokemon = JsonSerializer.Deserialize<Pokemon>(json);

                list.Add(pokemon);
                //Console.WriteLine(pokemon.PokemonName.ToUpper());
            }

            return list;
        }
    }
}