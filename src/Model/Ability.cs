using System.Text.Json.Serialization;

namespace bichinho_virtual_pokemon_csharp
{
    public class Abilities
    {
        [property: JsonPropertyName("ability")]
        public Ability Ability { get; set; }
    }

    public class Ability
    {
        [property: JsonPropertyName("name")]
        public string AbilityName { get; set; }
    }
}