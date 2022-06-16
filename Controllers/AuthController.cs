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
        private readonly JwtHandler _jwtHandler;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(AppDbContext context,SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,ClientsService clientsService,JwtHandler jwtHandler)
        {
            _clientsService = clientsService;
            _context = context;
            _jwtHandler = jwtHandler;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel userForAuthentication)
        {
            if(userForAuthentication is null)
            {
                return BadRequest("Invalid client request");
            }

            var user = await _userManager.FindByNameAsync(userForAuthentication.UserName);

            if(user == null || !await _userManager.CheckPasswordAsync(user,userForAuthentication.Password))
            {
                return Unauthorized("Invalid Authentication");
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user.UserName,userForAuthentication.Password,false,lockoutOnFailure: true);

            if(loginResult.Succeeded)
            {
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = await _jwtHandler.GetClaims(user);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials,claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token });
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

            await _userManager.AddToRoleAsync(user, "Client");

            return Ok(); 
        }
    }
}