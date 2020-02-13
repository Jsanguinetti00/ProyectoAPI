using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using apiDiabetes.Controllers;
using apiDiabetes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace apiDiabetes.Metodos
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<UsuariosController> _userManager;
        private readonly SignInManager<UsuariosController> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<UsuariosController> userManager, SignInManager<UsuariosController> singInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = singInManager;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult>Login([FromBody] Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(usuario.Telefono, usuario.Contrasena, isPersistent: false, lockoutOnFailure: false);
                if(result.Succeeded)
                {
                    return BuildToken(usuario);
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid login attemp");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        private IActionResult BuildToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Telefono),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key_Token"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);


            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            }
            );
        }


    }
}