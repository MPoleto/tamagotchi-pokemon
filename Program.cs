using System.Text;
using AutoMapper;
using bichinho_virtual_pokemon_csharp;

Console.OutputEncoding = Encoding.UTF8;


string url = "https://pokeapi.co/api/v2/pokemon/";
using HttpClient client = new();

var pokemons =  await PokemonAPI.GetPokemonAsync(client, url);

if (pokemons.Any())
{
    var config = new MapperConfiguration(cfg => {
        cfg.AddProfile<ModelToDTOProfile>();
    });

    Console.Clear();

    var message = new MessageView();
    var mapper = new Mapper(config);

    new TamagotchiController(message, mapper).MenuTamagotchi(pokemons);
}
else
{
    Console.WriteLine("Não foi possível obter a lista de pokemons para adoção.");
}





