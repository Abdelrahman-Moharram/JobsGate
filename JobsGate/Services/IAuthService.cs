using JobsGate.DTO.Accounts;
using JobsGate.Models;
using System.IdentityModel.Tokens.Jwt;

namespace JobsGate.Services
{
    public interface IAuthService
    {
        Task<AuthResultDTO> Register(RegisterDTO userDTO);
        Task<JwtSecurityToken> CreateJWT(ApplicationUser user);
        Task<AuthResultDTO> Login(AuthLoginDTO loginDTO);
        Task<string> AddToRoleAsync(AddRoleDTO addRole);
    }
}
