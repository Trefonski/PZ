using PZ.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PZ.Models;
using PZ.Services;

namespace PZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ClientsService _clientsService;
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(AppDbContext context,SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,ClientsService clientsService)
        {
            _clientsService = clientsService;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user.UserName,user.Password,false,lockoutOnFailure: true);

            Console.WriteLine(loginResult);

            if(loginResult.Succeeded)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeymustbelong"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5100",
                    audience: "https://localhost:5100",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new AuthResponse { Token = tokenString });
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("registration")] 
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationModel userForRegistration) 
        {
            if(userForRegistration == null || !ModelState.IsValid) 
            {
                return BadRequest(); 
            }

            if(!userForRegistration.Password.Equals(userForRegistration.ConfirmPassword))
            {
                return BadRequest("Wprowadzone hasła nie są identyczne!");
            }
                    
            var client = await _clientsService.InsertClient(userForRegistration.UserName,$"{userForRegistration.FirstName} {userForRegistration.LastName}");

            var user = new AppUser { UserName = userForRegistration.UserName, Email = userForRegistration.UserName };

            var result = await _userManager.CreateAsync(user, userForRegistration.Password); 
            
            if(!result.Succeeded) 
            { 
                var errors = result.Errors.Select(e => e.Description); 
                        
                return BadRequest(errors); 
            }

            return Ok(); 
        }
    }
}