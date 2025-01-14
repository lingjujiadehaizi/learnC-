using AutoMapper;
using GameManagement.Entites;
using GameManagement.Entites.DTOs;

namespace GameManagement.HttpApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDTO>();
            CreateMap<Character, CharacterDTO>();
            CreateMap<Player, PlayerWithCharactersDTO>();

            CreateMap<PlayerForCreationDTO, Player>();
            CreateMap<PlayerForUpdateDTO, Player>();
        }
    }
}
