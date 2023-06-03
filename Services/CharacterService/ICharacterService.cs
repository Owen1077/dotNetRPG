using dotnet_rpg.Dtos.CharacterDto;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacters>>> GetAllCharacters(int userId);
        Task<ServiceResponse<GetCharacters>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacters>>> AddCharacter(AddCharacters newCharacter);
        Task<ServiceResponse<GetCharacters>> UpdateCharacter(UpdateCharacters updatedCharacter);
        Task<ServiceResponse<List<GetCharacters>>> DeleteCharacter(int id);
    }
}
