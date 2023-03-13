using AutoMapper;
using dotnet_rpg.Dtos;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Id = 1, Name = "Sam"}
        };


        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetCharacters>>> AddCharacter(AddCharacters newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacters>>();

            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;

            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacters>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCharacters>>> GetAllCharacters()
        {

            return new ServiceResponse<List<GetCharacters>> 
            {
                Data = characters.Select(c => _mapper.Map<GetCharacters>(c)).ToList()
            };
        }
        public async Task<ServiceResponse<GetCharacters>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacters>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacters>(character);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacters>> UpdateCharacter(UpdateCharacters updatedCharacter)
        {
            ServiceResponse<GetCharacters> response = new ServiceResponse<GetCharacters>();

            try
            {


                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                character.Name = updatedCharacter.Name;
                character.Strength = updatedCharacter.Strength;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Defense = updatedCharacter.Defense;
                character.Class = updatedCharacter.Class;
                character.Intelligence = updatedCharacter.Intelligence;

                response.Data = _mapper.Map<GetCharacters>(character);

            } catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }
    }
}
