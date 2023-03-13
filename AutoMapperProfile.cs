using AutoMapper;
using dotnet_rpg.Dtos;
using dotnet_rpg.Models;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacters>();
            CreateMap<AddCharacters, Character>();
        }
    }
}
