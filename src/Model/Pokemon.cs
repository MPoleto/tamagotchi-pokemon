
using System.Text.Json.Serialization;

namespace bichinho_virtual_pokemon_csharp
{
    public class Pokemon
    {
        [property: JsonPropertyName("id")]
        public int ID { get; set; }


        [property: JsonPropertyName("name")]
        public string PokemonName { get; set; }


        [property: JsonPropertyName("types")]
        public List<Types> Types { get; set; }


        [property: JsonPropertyName("base_experience")]
        public int Experience { get; set; }


        [property: JsonPropertyName("abilities")]
        public List<Abilities> Abilities { get; set; }

        public int Hunger { get; set; }

        public int Play { get; set; }

        public int Sleep { get; set; }

        public Pokemon()
        {
            this.Hunger = 6;
            this.Play = 6;
            this.Sleep = 6;
        }

    }
}