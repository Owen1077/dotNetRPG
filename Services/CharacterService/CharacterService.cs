using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.CharacterDto;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId()
        {
            return (int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }


        public async Task<ServiceResponse<List<GetCharacters>>> AddCharacter(AddCharacters newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacters>>();

            Character character = _mapper.Map<Character>(newCharacter);
            character.User = await _context.Users.FirstOrDefaultAsync(c => c.Id == GetUserId());

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Characters
                .Where(c => c.User.Id == GetUserId())
                .Select(c => _mapper.Map<GetCharacters>(c)).ToListAsync();
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharacters>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacters>> response = new ServiceResponse<List<GetCharacters>>();

            try
            {
                var character = await _context.Characters.FirstAsync(c => c.Id == id && c.User.Id == GetUserId());
                
                if(character != null)
                {
                    _context.Characters.Remove(character);
                    await _context.SaveChangesAsync();

                    response.Data = _context.Characters
                    .Where(c => c.User.Id == GetUserId())
                    .Select( c => _mapper.Map<GetCharacters>(c)).ToList();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Character not found";
                }
                
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ServiceResponse<List<GetCharacters>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacters>> response = new ServiceResponse<List<GetCharacters>>();
            var dbCharacters = await _context.Characters
                .Where(c => c.User.Id == GetUserId())
                .ToListAsync();
            response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacters>(c)).ToList();

            return response;
        }


        public async Task<ServiceResponse<GetCharacters>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacters>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetCharacters>(dbCharacter);

            return serviceResponse;
        }


        public async Task<ServiceResponse<GetCharacters>> UpdateCharacter(UpdateCharacters updatedCharacter)
        {
            ServiceResponse<GetCharacters> response = new ServiceResponse<GetCharacters>();

            try
            {
                var character = await _context.Characters
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

                if(character.User.Id == GetUserId())
                {
                    character.Name = updatedCharacter.Name;
                    character.Strength = updatedCharacter.Strength;
                    character.HitPoints = updatedCharacter.HitPoints;
                    character.Defense = updatedCharacter.Defense;
                    character.Class = updatedCharacter.Class;
                    character.Intelligence = updatedCharacter.Intelligence;

                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetCharacters>(character);
                } else
                {
                    response.Success = false;
                    response.Message = "Character not found";
                }
                

            } catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
