using System.Text.Json.Serialization;

namespace bichinho_virtual_pokemon_csharp
{
  public class Types
  {
      [property: JsonPropertyName("type")]
      public Type Type { get; set; }
  }

  public class Type
  {
      [property: JsonPropertyName("name")]
      public string TypeName { get; set; }
  }
}