namespace bichinho_virtual_pokemon_csharp
{
  public class MessageView
  {
    private HashSet<Pokemon> MyVirtualPets = new();
    public string Welcome()
    {
      Console.WriteLine("\nBEM-VINDO(A)!!!");
      Console.WriteLine("\nQual o seu nome?");
      var gamer = new User().UserName;
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
      Console.WriteLine("2 - Ver seus mascotes");
      Console.WriteLine("3 - Sair");
      Console.Write("\nDigite a opção desejada: ");
    }

    public void ShowMyPets()
    {
      Console.Clear();

      Console.WriteLine("_________________ MEUS  MASCOTES _________________\n");

      if (MyVirtualPets.Count == 0)
      {
        Console.WriteLine("\nVocê ainda não adotou nenhum mascote.\n");
      }
      foreach (var pet in MyVirtualPets)
      {
        Console.WriteLine(pet.PokemonName.ToUpper());
      }

      Console.WriteLine("__________________________________________________");
      Console.WriteLine("\n\nPressione uma tecla para continuar...");
      Console.ReadKey();
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
      //Console.WriteLine("__________________________________________________\n");
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
        }
      }
      Console.WriteLine("\n\n__________________________________________________");
      Console.WriteLine("\n\nPressione uma tecla para continuar...");
      Console.ReadKey();
    }

    public void AdoptVirtualPet(string virtualPet, HashSet<Pokemon> VirtualPets)
    {
      Console.WriteLine("\n__________________________________________________");
      
      foreach (var pet in VirtualPets)
      {
        if (pet.PokemonName.ToUpper() == virtualPet)
        {
          if (MyVirtualPets.Contains(pet))
          {
            Console.WriteLine($"\n\nVocê já adotou o {virtualPet}, escolha outra espécie!");

          }
          else
          {
            MyVirtualPets.Add(pet);
            Console.WriteLine($"\n\n{virtualPet} FOI ADOTADO COM SUCESSO!");
          }

        }
      }

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