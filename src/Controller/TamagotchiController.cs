using AutoMapper;

namespace bichinho_virtual_pokemon_csharp
{
  public class TamagotchiController
  {
    private readonly MessageView _message;
    private readonly PokemonService _service;
    private readonly IMapper _mapper;
    private Pokemon myPokemon;
    private PokemonDTO myPet;

    public TamagotchiController(MessageView message, IMapper mapper)
    {
      this._message = message;
      this._mapper = mapper;
      this._service = new PokemonService();
      this.myPokemon = new();
      this.myPet = new();
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
              MyVirtualPet(gamer, VirtualPets);
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
        throw new Exception($"{ex.Message} Aplicação encerrada incorretamente.");
      }
    }

    private void ChooseVirtualPet(string gamer, HashSet<Pokemon> VirtualPets)
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

        if (petSelected.StartsWith("X"))
        {
          break;
        }

        Console.WriteLine("Mascote não encontrado. Verifique o nome e digite novamente.\n");

      }
    }

    private void MenuAdoption(string gamer, string virtualPet, HashSet<Pokemon> VirtualPets)
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
              AdoptVirtualPet(virtualPet, VirtualPets);
              break;
            case '3':
              break;
            default:
              Console.WriteLine("Opção inválida.");
              break;
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"\n{ex.Message} Aplicação encerrada incorretamente. {ex.StackTrace}");
      }
    }

    private void AdoptVirtualPet(string virtualPet, HashSet<Pokemon> VirtualPets)
    {
      Console.WriteLine("\n__________________________________________________");
      
      myPokemon = _service.FindPokemon(virtualPet, myPokemon, VirtualPets);

      myPet = _mapper.Map<PokemonDTO>(myPokemon); 

      _message.PressToContinue();      
    }

    private void MyVirtualPet(string gamer, HashSet<Pokemon> VirtualPets)
    {
      try
      {
        char option = '0';
        while (option != 'X')
        {
          Console.Clear();
          _message.MyPetMenu(gamer, myPet);

          option = Console.ReadLine().ToUpper()[0];

          Console.WriteLine("\n__________________________________________________\n\n");

          switch (option)
          {
            case '1':
              _service.StatusMyPokemon(myPet);
              _message.PressToContinue();
              break;
            case '2':
              _service.FeedMyPet(myPet);
              _message.PressToContinue();
              break;
            case '3':
              _service.PlayMyPet(myPet);
              _message.PressToContinue();
              break;
            case '4':
              _service.SleepMyPet(myPet);
              _message.PressToContinue();
              break;
            case '5':
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