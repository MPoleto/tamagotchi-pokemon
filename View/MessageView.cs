namespace bichinho_virtual_pokemon_csharp
{
  public class MessageView
  {
    
    public string Welcome()
    {
      Console.WriteLine("\nBEM-VINDO(A)!!!");
      Console.WriteLine("\nQual o seu nome?");
      string gamer = "";
      bool invalid = true;

      while (invalid)
      {
        gamer = Console.ReadLine().Trim();

        if (gamer.Length > 0) invalid = false;
        else Console.WriteLine("Nome inválido. Por favor, adicione um nome.");

      }

      Console.WriteLine($"\nOLÁ, {gamer.ToUpper()}!\n");

      return gamer;
    }

    public void MainMenu(string gamer)
    {
      Console.WriteLine("______________________ MENU ______________________");
      Console.WriteLine($"\n{gamer}, você deseja:");
      Console.WriteLine("1 - Adotar um mascote");
      Console.WriteLine("2 - Meu mascote");
      Console.WriteLine("3 - Sair");
      Console.WriteLine();
      Console.Write("\nDigite a opção desejada: ");
    }
    
    public void PetsForAdoption(string gamer, HashSet<Pokemon> VirtualPets)
    {
      Console.WriteLine("_________________ ADOTAR MASCOTE _________________");
      Console.WriteLine($"\n{gamer}, escolha uma espécie:");

      foreach (var pet in VirtualPets)
      {
        Console.WriteLine(pet.PokemonName.ToUpper());
      }

      Console.WriteLine("\nX - Voltar\n");
    }

    public void SubmenuPet(string gamer, string virtualPet)
    {
      Console.WriteLine("__________________________________________________\n");
      Console.WriteLine($"{gamer}, você deseja:");
      Console.WriteLine($"1 - Saber mais sobre o {virtualPet}");
      Console.WriteLine($"2 - Adotar o {virtualPet}");
      Console.WriteLine("3 - Voltar");
      Console.Write("\nDigite a opção desejada: ");
    }

    public void AboutVirtualPet(string virtualPet, HashSet<Pokemon> VirtualPets)
    {
      Console.Clear();

      Console.WriteLine("__________________________________________________\n\n");

      foreach (var pet in VirtualPets)
      {
        if (pet.PokemonName.ToUpper() == virtualPet)
        {
          Console.WriteLine($"Nome: {pet.PokemonName.ToUpper()}");
          Console.WriteLine($"ID: {pet.ID}");

          Console.Write($"Tipo(s): ");
          foreach (var type in pet.Types)
          {
            Console.Write($"{type.Type.TypeName} ");

          }
          Console.WriteLine($"\nExperiência inicial: {pet.Experience}");
          Console.Write($"Habilidade(s): ");
          foreach (var ability in pet.Abilities)
          {
            Console.Write($"{ability.Ability.AbilityName} ");
          }
          Console.Write("\n");
        }
      }
      PressToContinue();
    }

    public void MyPetMenu(string gamer, Pokemon myPet)
    {
      Console.WriteLine("__________________ MEU  MASCOTE __________________\n");

      // RESOLVER
      if (myPet.PokemonName == null)
      {
        Console.WriteLine("\nVocê ainda não adotou um mascote.");
        Console.WriteLine("\nX - Voltar\n");
      }
      else
      {
        Console.WriteLine($"{gamer}, você deseja:");
        Console.WriteLine($"1 - Saber como está o {myPet.PokemonName.ToUpper()}");
        Console.WriteLine($"2 - Alimentar");
        Console.WriteLine($"3 - Brincar");
        Console.WriteLine($"4 - Dormir");
        Console.WriteLine("\nX - Voltar");
        Console.Write("\nDigite a opção desejada: ");
      }
    }

    public void PressToContinue()
    {
      Console.WriteLine("\n__________________________________________________");
      Console.WriteLine("\n\nPressione uma tecla para continuar...");
      Console.ReadKey();
    }

    public void CloseApplication()
    {
      Console.WriteLine("\n__________________________________________________");
      Console.WriteLine("\n\n... Aplicação encerrada ...\n");
    }
  }
}