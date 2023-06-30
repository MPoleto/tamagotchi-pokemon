namespace bichinho_virtual_pokemon_csharp
{
    public class PokemonDTO
    {
        public int ID { get; set; }

        public string PokemonName { get; set; }

        public List<Types> Types { get; set; }

        public int Experience { get; set; }

        public List<Abilities> Abilities { get; set; }

        public int Hunger { get; set; }

        public int Play { get; set; }

        public int Sleep { get; set; }

        public PokemonDTO()
        {
            this.Hunger = 6;
            this.Play = 6;
            this.Sleep = 6;
        }
    }
}