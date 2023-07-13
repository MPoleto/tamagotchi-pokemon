using System.Text.Json;

namespace bichinho_virtual_pokemon_csharp
{
  public static class PokemonAPI
  {
    private static HashSet<Pokemon> VirtualPets = new();
    
    public static async Task<HashSet<Pokemon>> GetPokemonAsync(HttpClient client, string url)
    {
      while (VirtualPets.Count <= 5)
      {
        var id = RafflePokemonID();

        try
        {
          string json = await client.GetStringAsync($"{url}{id:N0}");

          var pokemon = JsonSerializer.Deserialize<Pokemon>(json);

          VirtualPets.Add(pokemon);
          
        }
        catch (HttpRequestException exception)
        {
          Console.WriteLine("Verifique o endereço informado. " + exception.Message);
          break;
        }
        catch (JsonException exception)
        {
          Console.WriteLine($"Erro Encontrado: {exception.Message}");
          break;
        }
        catch (Exception exception)
        {
          Console.WriteLine($"Ocorreu um erro durante a consulta a API. Erro encontrado: {exception.Message}");
          break;
        }
      }
      return VirtualPets;
    }

    private static int RafflePokemonID()
    {
      var number = new Random();
      int id = 0;
      bool invalid = true;

      while (invalid)
      {
        id = number.Next(1, 200);

        bool exist = false;
        foreach (var virtualPet in VirtualPets)
        {
          if (virtualPet.ID == id)
          {
            exist = true;
            break;
          }
        }
        if (!exist)
        {
          invalid = false;
        }
      }
      return id;
    }
  }
}