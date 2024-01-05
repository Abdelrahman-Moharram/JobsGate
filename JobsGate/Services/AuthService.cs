using JobsGate.DTO.Accounts;
using JobsGate.Helpers;
using JobsGate.Models;
using JobsGate.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobsGate.Services
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JWTSettings jwt;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IBaseRepository<Employee> EmployeeRepository;
        private readonly IBaseRepository<Employer> EmployerRepository;
        public AuthService(
            UserManager<ApplicationUser> _userManager, 
            IOptions<JWTSettings> _jwt, 
            RoleManager<IdentityRole> _roleManager, 
            IBaseRepository<Employee> _EmployeeRepository,
            IBaseRepository<Employer> _EmployerRepository
            )
        {
            userManager = _userManager;
            jwt = _jwt.Value;
            roleManager = _roleManager;
            EmployeeRepository = _EmployeeRepository;
            EmployerRepository = _EmployerRepository;
        }


        public async Task<AuthResultDTO> Register(RegisterDTO userDTO)
        {
            if (await userManager.FindByEmailAsync(userDTO.Email) != null) return new AuthResultDTO {IsAuthenticated = false, Message = "This Email already exists!"};
            if (await userManager.FindByNameAsync(userDTO.UserName) != null) return new AuthResultDTO{IsAuthenticated = false,Message = "This UserName already exists!"};
            if (await roleManager.FindByNameAsync(userDTO.RegisterAs) == null) return new AuthResultDTO { IsAuthenticated = false, Message = userDTO.RegisterAs + " is Invalid Role" };
            ApplicationUser user = new ApplicationUser 
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
            };
            var result =  await userManager.CreateAsync(user, userDTO.Password);
            if (!result.Succeeded) return new AuthResultDTO { IsAuthenticated = false, Message = "Something went wrong cantact with admin!" };

            result = await userManager.AddToRoleAsync(user, userDTO.RegisterAs);
            if (!result.Succeeded) return new AuthResultDTO { IsAuthenticated = false, Message = "Something went wrong cantact with admin!" };


            if (!await CreateUserRole(user.Id, userDTO.RegisterAs))
                return new AuthResultDTO { IsAuthenticated = false, Message = userDTO.RegisterAs + " is Invalid Role but you successfully registered, please contact the admin!" };

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

        public async Task<string> AddToRoleAsync(AddRoleDTO addRole)
        {
            ApplicationUser user = await userManager.FindByIdAsync(addRole.userId);
            IdentityRole role = await roleManager.FindByNameAsync(addRole.roleName);
            if (user != null && role != null)
            {
                if (await userManager.IsInRoleAsync(user, addRole.roleName))
                    return "User already assigned to this role";

                var result = await userManager.AddToRoleAsync(user, addRole.roleName);
                if (result.Succeeded)
                {
                    
                    return user.UserName + " added to " + addRole.roleName + " Successfully";
                }
                return "Something went wrong";
            }
            return "Invalid user or Role";
        }
        public async Task<bool> CreateUserRole(string userId, string role)
        {
            if(role?.ToLower() == "employee")
            {
                EmployeeRepository.AddAsync(new Employee
                {
                    UserId = userId,
                });
                EmployeeRepository.Save();
                return true;
            }
            else if(role?.ToLower() == "employer")
            {
                EmployerRepository.AddAsync(new Employer
                {
                    UserId = userId,
                });
                EmployerRepository.Save();

                return true;
            }
            else if (role?.ToLower() == "admin")
            {
                return true;
            }
            return false;
        }
    }
}
