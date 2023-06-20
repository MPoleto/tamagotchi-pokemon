namespace bichinho_virtual_pokemon_csharp
{
  public class TamagotchiController
  {
    private readonly MessageView _message;

    public TamagotchiController(MessageView message)
    {
      this._message = message;
    }

    public void MenuTamagotchi(HashSet<Pokemon> VirtualPets)
    {
      try
      {
        var gamer = _message.Welcome();

        char option = '0';
        while (option != '3')
        {
          Console.Clear();
          _message.MainMenu(gamer);

          option = Console.ReadLine()[0];

          switch (option)
          {
            case '1':
              ChooseVirtualPet(gamer, VirtualPets);
              break;
            case '2':
              _message.ShowMyPets();
              break;
            case '3':
              _message.CloseApplication();
              break;
            default:
              Console.WriteLine("Opção inválida. Tente novamente.");
              break;
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"\nAplicação encerrada incorretamente. {ex.Message}");
      }
    }

    public void ChooseVirtualPet(string gamer, HashSet<Pokemon> VirtualPets)
    {
      Console.Clear();
      _message.PetsForAdoption(gamer, VirtualPets);

      var notFound = true;

      while (notFound)
      {
        var petSelected = Console.ReadLine().ToUpper().Trim();

        foreach (var pet in VirtualPets)
        {
          if (pet.PokemonName.ToUpper() == petSelected)
          {
            notFound = false;
            MenuAdoption(gamer, petSelected, VirtualPets);
          }
        }

        if (petSelected.StartsWith("X") || petSelected.StartsWith("x"))
        {
          break;
        }

        Console.WriteLine("Mascote não encontrado. Verifique o nome e digite novamente.\n");

      }
    }

    void MenuAdoption(string gamer, string virtualPet, HashSet<Pokemon> VirtualPets)
    {
      try
      {
        char option = '0';
        while (option != '3')
        {
          Console.Clear();
          _message.SubmenuPet(gamer, virtualPet);

          option = Console.ReadLine()[0];

          switch (option)
          {
            case '1':
              _message.AboutVirtualPet(virtualPet, VirtualPets);
              break;
            case '2':
              _message.AdoptVirtualPet(virtualPet, VirtualPets);
              break;
            case '3':
              ChooseVirtualPet(gamer, VirtualPets);
              break;
            default:
              Console.WriteLine("Opção inválida.");
              break;
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"\nAplicação encerrada incorretamente. {ex.Message}");
      }
    }
  }
}