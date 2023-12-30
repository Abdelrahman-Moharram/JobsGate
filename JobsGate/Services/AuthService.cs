using JobsGate.DTO.Accounts;
using JobsGate.Helpers;
using JobsGate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobsGate.Services
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JWTSettings jwt;
        public AuthService(UserManager<ApplicationUser> _userManager, IOptions<JWTSettings> _jwt)
        {
            userManager = _userManager;
            jwt = _jwt.Value;
        }


        public async Task<AuthResultDTO> Register(RegisterDTO userDTO)
        {
            if (await userManager.FindByEmailAsync(userDTO.Email) != null) return new AuthResultDTO {IsAuthenticated = false, Message = "This Email already exists!"};
            if (await userManager.FindByNameAsync(userDTO.UserName) != null) return new AuthResultDTO{IsAuthenticated = false,Message = "This UserName already exists!"};

            ApplicationUser user = new ApplicationUser 
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
            };
            var result =  await userManager.CreateAsync(user, userDTO.Password);
            if (!result.Succeeded) return new AuthResultDTO { IsAuthenticated = false, Message = "Something went wrong cantact with admin!" };

            result = await userManager.AddToRoleAsync(user, "User");
            if (!result.Succeeded) return new AuthResultDTO { IsAuthenticated = false, Message = "Something went wrong cantact with admin!" };

            JwtSecurityToken token = await CreateJWT(user);

            

            return  new AuthResultDTO 
            {
                IsAuthenticated = true , 
                Message = user.UserName + " Created Successfully",
                UserEmail = userDTO.Email,
                UserName = userDTO.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            
        }


        public async Task<AuthResultDTO> Login(AuthLoginDTO loginDTO)
        {
            ApplicationUser user;
            if (loginDTO.UserName.IsEmail()) 
                user = await userManager.FindByEmailAsync(loginDTO.UserName);
            else 
                user = await userManager.FindByNameAsync(loginDTO.UserName);
            
            if (user == null || !(await userManager.CheckPasswordAsync(user, loginDTO.Password))) 
                return new AuthResultDTO { IsAuthenticated = false, Message = "User or Password is Invalid" };
            
            JwtSecurityToken token = await CreateJWT(user);
            return new AuthResultDTO
            {
                IsAuthenticated = true,
                Message = user.UserName + " LoggedIn Successfully",
                UserEmail = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

        }

        public async Task<JwtSecurityToken> CreateJWT(ApplicationUser user)
        {


            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));



            var Claims = new List<Claim>
                {
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                       new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                       new Claim(JwtRegisteredClaimNames.Email, user.Email),
                       new Claim(ClaimTypes.NameIdentifier, user.Id),
                       new Claim(ClaimTypes.Role, "User"),
                }
            .Union(userClaims)
            .Union(roleClaims);

            SigningCredentials credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SECRETKEY)), 
                SecurityAlgorithms.HmacSha256
                );

            return new JwtSecurityToken(
                claims: Claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddDays(jwt.DurationInDays),
                audience:jwt.Audience,
                issuer: jwt.Issuer
             );
        }

    }
}
