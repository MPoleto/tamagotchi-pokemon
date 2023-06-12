using System.Text.Json.Serialization;

namespace bichinho_virtual_pokemon_csharp
{
    public class Abilities
    {
        [property: JsonPropertyName("ability")]
        public Ability Ability { get; set; }

        [property: JsonPropertyName("is_hidden")]
        public bool Hidden { get; set; }
    }

  public class Ability
  {
    [property: JsonPropertyName("name")]
        public string Name { get; set; }
  }
}