using System.Text.Json;
using bichinho_virtual_pokemon_csharp;

using HttpClient client = new();
//var url = "https://pokeapi.co/api/v2/pokemon/";

await GetPokemonAPIAsync(client);


static async Task GetPokemonAPIAsync(HttpClient client)
{
  var number = new Random();

  for (int i = 1; i < 5; i++)
  {
    var id = number.Next(1, 81);
    var json = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id:N0}");
    ShowCharacteristics(json);
    
  }
}

static void ShowCharacteristics(string json)
{
  var result = JsonSerializer.Deserialize<Pokemon>(json);
    
    Console.WriteLine($"ID: {result.ID}");
    Console.WriteLine($"Nome: {result.Name.ToUpper()}");
    Console.WriteLine($"Altura: {result.Height}");
    Console.WriteLine($"Experiência inicial: {result.Experience}");
    Console.WriteLine($"Habilidades:");

    foreach (var item in result.Abilities)
    {
      Console.WriteLine($"{item.Ability.Name.ToUpper()}");
      
    }
    Console.WriteLine();
}
