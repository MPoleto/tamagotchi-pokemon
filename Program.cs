using System.Text;
using bichinho_virtual_pokemon_csharp;

Console.OutputEncoding = Encoding.UTF8;

#nullable disable

string url = "https://pokeapi.co/api/v2/pokemon/";
using HttpClient client = new();

var pokemons =  await PokemonAPI.GetPokemonAsync(client, url);

Console.Clear();

var message = new MessageView();

new TamagotchiController(message).MenuTamagotchi(pokemons);





