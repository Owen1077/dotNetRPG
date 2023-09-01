using dotnet_rpg.Dtos.CharacterDto;
using dotnet_rpg.Dtos.WeaponsDto;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacters>> AddWeapon(AddWeaponsDto newWeapon);

    }
}
