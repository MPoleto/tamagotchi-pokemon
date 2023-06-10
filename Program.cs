using System.Text.Json;
using bichinho_virtual_pokemon_csharp;

using HttpClient client = new();
//var url = "https://pokeapi.co/api/v2/pokemon/";

await GetPokemonAPIAsync(client);


static async Task GetPokemonAPIAsync(HttpClient client)
{
  for (int i = 1; i < 5; i++)
  {
    var json = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{i}");

    var result = JsonSerializer.Deserialize<Pokemon>(json);
    Console.WriteLine(result);
    
  }

}

