using AutoMapper;
using dotnet_rpg.Dtos.CharacterDto;
using dotnet_rpg.Dtos.WeaponsDto;
using dotnet_rpg.Models;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacters>();
            CreateMap<AddCharacters, Character>();
            CreateMap<UpdateCharacters, Character>();
            CreateMap<Weapon, GetWeaponDto>();
        }
    }
}
