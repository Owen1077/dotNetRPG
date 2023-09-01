using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.CharacterDto;
using dotnet_rpg.Dtos.WeaponsDto;
using dotnet_rpg.Models;

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

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

        }
    }
}
