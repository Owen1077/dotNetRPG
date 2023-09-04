using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.CharacterDto;
using dotnet_rpg.Dtos.WeaponsDto;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace dotnet_rpg.Services.WeaponService
{
    public class WeaponService: IWeaponService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WeaponService(IHttpContextAccessor httpContextAccessor, DataContext context, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCharacters>> AddWeapon(AddWeaponsDto newWeapon)
        {
            ServiceResponse<GetCharacters> response = new ServiceResponse<GetCharacters>();
            try
            {
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
                c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if(character == null)
                {
                    response.Success = false;
                    response.Message = "Character not found";
                }

                Weapon weapon = new Weapon 
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Character = character
                };

                _context.Weapons.Add(weapon);
                _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacters>(character);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
