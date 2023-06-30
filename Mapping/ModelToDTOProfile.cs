using AutoMapper;

namespace bichinho_virtual_pokemon_csharp
{
  public class ModelToDTOProfile : Profile
  {
    public ModelToDTOProfile()
    {
      CreateMap<Pokemon, PokemonDTO>()
        .ForMember(dest => dest.Abilities, opt => opt.MapFrom(src => src.Abilities))
        .ForMember(dest => dest.Types, opt => opt.MapFrom(src => src.Types));
    }
  }
}