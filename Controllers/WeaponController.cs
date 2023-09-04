using dotnet_rpg.Dtos.CharacterDto;
using dotnet_rpg.Dtos.WeaponsDto;
using dotnet_rpg.Models;
using dotnet_rpg.Services.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;
        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacters>>> AddWeapon(AddWeaponsDto newWeapon)
        {
            return Ok(await _weaponService.AddWeapon(newWeapon));
        }




    }
}
