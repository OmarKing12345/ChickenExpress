using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChickenExpress.Application.DTO;
using ChickenExpress.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using ChickenExpress.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
 

namespace ChickenExpress.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;



        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        private async Task EnsureRolesExist()
        {
            if (_roleManager.Roles.Any()) return;

            var roles = new[] { SD.Admin, SD.SuperAdmin, SD.USer, SD.Company };
            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }


        private string GenerateEmailConfirmationLink(string userId, string token)
        {
            return Url.Action("ConfirmEmail", "Account",
                new { area = "Identity", userId, token },
                Request.Scheme);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await EnsureRolesExist();


            var applicationUser = new ApplicationUser
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email
            };


            var result = await _userManager.CreateAsync(applicationUser, registerDTO.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            await _userManager.AddToRoleAsync(applicationUser, SD.USer);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
            var confirmationLink = GenerateEmailConfirmationLink(applicationUser.Id, token);
            await _emailSender.SendEmailAsync(
                applicationUser.Email,
                "Confirm Your Email",
                $"<h1>Please confirm your account by clicking <a href='{confirmationLink}'>here</a></h1>");
            return Ok(result);
 

        }

         [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
                return BadRequest(new { message = "Invalid confirmation details." });

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound(new { message = "User not found." });

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
                return Ok(new { message = "Email confirmed successfully!" });
            else
                return BadRequest(new { message = "Email not confirmed.", errors = result.Errors });
        }



        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto loginDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(loginDTO.UserNameOrEmail)
                ?? await _userManager.FindByEmailAsync(loginDTO.UserNameOrEmail);

              

            if (user == null)
                return BadRequest(new { message = "There is no user with this username or email" });

            if (!await _userManager.IsEmailConfirmedAsync(user))
                return BadRequest(new { message = "The email is not confirmed" });
            var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);

            if (!result)
                return BadRequest(new { message = "The password is not correct" });



            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
             {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("Email", user.Email ?? "")

             };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eqlkjrljlejrljljghhljflwqlfhuhfuhougoivsldjckklzlkjvlsajkvhjkqevkjeqkjfvukqlv"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var JWToken = new JwtSecurityToken
                (
                 issuer: "https://localhost:7115/",
                 audience: "http://localhost:4200/",
                 claims: claims,
                 expires: DateTime.UtcNow.AddHours(2),
                 signingCredentials: creds
            );


            var tokenString = new JwtSecurityTokenHandler().WriteToken(JWToken);

            return Ok(new { token = tokenString });


        }


        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordDto forgetPassworddto)
        {
            var applicationUser = await _userManager.FindByNameAsync(forgetPassworddto.UserNameOrEmail)
                ?? await _userManager.FindByEmailAsync(forgetPassworddto.UserNameOrEmail);

            if (applicationUser is null)
                return BadRequest(new { message = "User not found" });

            string token = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);

             var resetPasswordUrl = Url.Action(
                "ResetPassword",
                "Account",
                new { userId = applicationUser.Id, token },
                Request.Scheme
            );

            await _emailSender.SendEmailAsync(
                applicationUser.Email,
                "Reset Password",
                $"<h1>Reset your password by clicking <a href='{resetPasswordUrl}'>here</a></h1>"
            );

            return Ok(new { message = "Password reset link sent to email" });
        }




        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
                return BadRequest(new { message = "User not found" });

            var result = await _userManager.ResetPasswordAsync(user, model.token, model.NewPassword);

            if (result.Succeeded)
                return Ok(new { message = "Password reset successfully" });

            return BadRequest(new { message = "Password reset failed", errors = result.Errors.Select(e => e.Description) });
        }

    }
}
