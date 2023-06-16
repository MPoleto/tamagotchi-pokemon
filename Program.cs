using bichinho_virtual_pokemon_csharp;

#nullable disable

string url = "https://pokeapi.co/api/v2/pokemon/";
using HttpClient client = new();
List<Pokemon> VirtualPets = new();

await PokemonAPI.GetPokemonAsync(client, url, VirtualPets);

List<Pokemon> MyVirtualPets = new();


Console.Clear();
Console.WriteLine("\nBEM-VINDO(A)!!!");
Console.WriteLine("\nQual o seu nome?");
var gamer = new User();
bool invalid = true;

while (invalid)
{
  gamer.UserName = Console.ReadLine().Trim();

  if(gamer.UserName.Length > 0) invalid = false;
  else Console.WriteLine("Nome inválido. Por favor, adicione um nome.");
  
}

Console.WriteLine($"\nOlá, {gamer.UserName}!\n");

MenuTamagochi();

void MenuTamagochi()
{
  try
  {
    char option = '0';
    while (option != '3')
    {
      Console.Clear();
      Console.WriteLine("______________________ MENU ______________________");
      Console.WriteLine($"\n{gamer.UserName}, você deseja:");
      Console.WriteLine("1 - Adotar um mascote");
      Console.WriteLine("2 - Ver seus mascotes");
      Console.WriteLine("3 - Sair");
      Console.Write("\nDigite a opção desejada: ");

      try
      {
        option = Console.ReadLine()[0];
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }

      Console.WriteLine("\n__________________________________________________");

      switch (option)
      {
        case '1':
          ChooseVirtualPet();
          break;
        case '2':
          ShowMyPets();
          break;
        case '3':
          CloseApplication();
          break;
        default:
          Console.WriteLine("Opção inválida. Tente novamente.");
          break;
      }
    }
  }
  catch (System.Exception ex)
  {
    throw new Exception(ex.Message);
  }
}

void CloseApplication()
{
  Console.WriteLine("\n\n... Aplicação encerrada ...\n");
}

void ShowMyPets()
{
  Console.Clear();
 
  Console.WriteLine("_________________ MEUS  MASCOTES _________________\n");

  if (MyVirtualPets.Count == 0)
  {
    Console.WriteLine("\nVocê ainda não adotou nenhum mascote.\n");
  }
  foreach(var pet in MyVirtualPets)
  {
    Console.WriteLine(pet.PokemonName.ToUpper());
  }

  Console.WriteLine("__________________________________________________");
  Console.WriteLine("\n\nPressione uma tecla para continuar...");
  Console.ReadKey();

}

void ChooseVirtualPet()
{
  Console.Clear();
  Console.WriteLine("_________________ ADOTAR MASCOTE _________________");
  Console.WriteLine($"\n{gamer.UserName}, escolha uma espécie:");

  foreach (var pet in VirtualPets)
  {
    Console.WriteLine(pet.PokemonName.ToUpper());
  }

  Console.WriteLine("\nX - Voltar\n");

  var notFound = true;

  while (notFound)
  {
    var petSelected = Console.ReadLine().ToUpper().Trim();

    foreach (var pet in VirtualPets)
    {
      if(pet.PokemonName.ToUpper() == petSelected)
      {
        notFound = false;
        SubmenuAdoption(petSelected);
      } 
    }

    if (petSelected.StartsWith("X") || petSelected.StartsWith("x"))
    {
      //notFound = false;
      break;
    }

    Console.WriteLine("Mascote não encontrado. Verifique o nome e digite novamente.\n");
    
  }
}

void SubmenuAdoption(string virtualPet)
{
  try
  {
    char option = '0';
    while (option != '3')
    {
      Console.Clear();
      Console.WriteLine("__________________________________________________\n");
      Console.WriteLine($"{gamer.UserName}, você deseja:");
      Console.WriteLine($"1 - Saber mais sobre o {virtualPet}");
      Console.WriteLine($"2 - Adotar o {virtualPet}");
      Console.WriteLine("3 - Voltar");
      Console.Write("\nDigite a opção desejada: ");

      try
      {
        option = Console.ReadLine()[0];
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
      
      Console.WriteLine("\n__________________________________________________");

      switch (option)
      {
        case '1':
          AboutVirtualPet(virtualPet);
          break;
        case '2':
          AdoptVirtualPet(virtualPet);
          break;
        case '3':
          ChooseVirtualPet();
          break;
        default:
          Console.WriteLine("Opção inválida.");
          break;
      }
    }
  }
  catch (System.Exception ex)
  {
    throw new Exception(ex.Message);
  }
}

void AboutVirtualPet(string virtualPet)
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
      Console.Write($"Habilidades: ");
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

void AdoptVirtualPet(string virtualPet)
{
  foreach (var pet in VirtualPets)
  {
    if (pet.PokemonName.ToUpper() == virtualPet)
    {
      MyVirtualPets.Add(pet);

      Console.WriteLine($"\n\n{virtualPet} FOI ADOTADO COM SUCESSO!");
      
    }
  }

  Console.WriteLine("\n__________________________________________________");
  Console.WriteLine("\n\nPressione uma tecla para continuar...");
  Console.ReadKey();
}



