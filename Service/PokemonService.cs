using System.Text.Json;

namespace bichinho_virtual_pokemon_csharp
{
  public class PokemonService
  {
    public Pokemon FindPokemon(string pokemonName, Pokemon myPokemon, HashSet<Pokemon> Pokemons)
    {
      foreach (var pet in Pokemons)
      {
        if (pet.PokemonName.ToUpper() == pokemonName)
        {
          if (myPokemon.PokemonName != null)
          {
            Console.WriteLine($"\n\nVocê já adotou o {myPokemon.PokemonName.ToUpper()} como mascote!");
          }
          else
          {
            myPokemon = pet;

            Console.WriteLine($"\n\n{pokemonName} FOI ADOTADO COM SUCESSO!");
          }
          break;
        }
      }
        
      return myPokemon;
    }

    public void SleepMyPet(Pokemon myPokemon)
    {
      if (myPokemon.Sleep >= 10)
      {
        Console.WriteLine($"{myPokemon.PokemonName.ToUpper()} ESTÁ SEM SONO.");
      }
      else
      {
        myPokemon.Sleep+=3;
        myPokemon.Play-=2;
        myPokemon.Hunger--;

        MinimumStatus(myPokemon);
        MaximumStatus(myPokemon);

        Console.WriteLine($"{myPokemon.PokemonName.ToUpper()} DORMIU.\n\n(￣o￣) . z Z");
      }
    }

    public void PlayMyPet(Pokemon myPokemon)
    {
      if (myPokemon.Play == 10)
      {
        Console.WriteLine($"{myPokemon.PokemonName} NAO QUER BRINCAR AGORA.\n\no(〃＾▽＾〃)o");
      }
      else if (myPokemon.Hunger <= 2 || myPokemon.Sleep <= 2)
      {
        Console.WriteLine($"{myPokemon.PokemonName} ESTÁ SEM ENERGIA PARA BRINCAR. 🥴");
      }
      else
      {
        myPokemon.Play+=3;
        myPokemon.Hunger-=2;
        myPokemon.Sleep--;

        MinimumStatus(myPokemon);
        MaximumStatus(myPokemon);

        Console.WriteLine($" 🤩 {myPokemon.PokemonName.ToUpper()} SE DIVERTIU BRINCANDO.");
      }
    }

    public void FeedMyPet(Pokemon myPokemon)
    {
      if (myPokemon.Hunger == 10)
      {
        Console.WriteLine($"{myPokemon.PokemonName.ToUpper()} JÁ ESTÁ CHEIO.");
      }
      else
      {
        myPokemon.Hunger+=2;
        myPokemon.Sleep--;

        MinimumStatus(myPokemon);
        MaximumStatus(myPokemon);

        Console.WriteLine($"{myPokemon.PokemonName.ToUpper()} FOI ALIMENTADO. (╹ڡ╹ )");
      }
    }

    public void StatusMyPokemon(Pokemon myPokemon)
    {
      Console.Clear();
      Console.WriteLine("__________________________________________________\n\n");

      Console.WriteLine($"{myPokemon.Hunger} {myPokemon.Play} {myPokemon.Sleep}");

      if (myPokemon.Hunger > 6 && myPokemon.Play > 6 && myPokemon.Sleep > 6)
      {
        Console.WriteLine($"╰(*°▽ °*)╯");
        Console.WriteLine($"\n{myPokemon.PokemonName.ToUpper()} ESTÁ FELIZ.");
      }
      else if (myPokemon.Hunger < 5 && myPokemon.Play < 5 && myPokemon.Sleep < 5)
      {
        Console.WriteLine($"≡(▔﹏▔)≡");
        Console.WriteLine($"\n{myPokemon.PokemonName.ToUpper()} ESTÁ DOENTE.");
      }
      else
      {
        Console.WriteLine($"＜（＾－＾）＞");
        Console.WriteLine($"\n{myPokemon.PokemonName.ToUpper()} ESTÁ BEM.");
      }
      Console.Write($"\nAlimentação:  ");
      Barra(myPokemon.Hunger);
      Console.Write($"\nDiversão:     ");
      Barra(myPokemon.Play);
      Console.Write($"\nDescanso:     ");
      Barra(myPokemon.Sleep);
      
      Console.WriteLine();
    }

    private void MinimumStatus(Pokemon myPokemon)
    {
      if (myPokemon.Sleep < 0) myPokemon.Sleep = 0;
      
      if (myPokemon.Play < 0) myPokemon.Play = 0;

      if (myPokemon.Hunger < 0) myPokemon.Hunger = 0;  
    }

    private void MaximumStatus(Pokemon myPokemon)
    {
      if (myPokemon.Sleep >= 10) myPokemon.Sleep = 10;
      
      if (myPokemon.Play >= 10) myPokemon.Play = 10;

      if (myPokemon.Hunger >= 10) myPokemon.Hunger = 10;  
    }

    private void Barra(int prop)
    {
      for (var i = 1; i <= prop; i++)
      {
        if (prop > 0 && prop < 4) Console.Write("\u001b[31m *\u001b[m");
        else Console.Write("\u001b[34m *\u001b[m");
      }
    }
  }
}