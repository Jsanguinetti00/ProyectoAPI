using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using apiDiabetes.Controllers;
using apiDiabetes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace apiDiabetes.Metodos
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<UsuariosController> _userManager;
        private readonly SignInManager<UsuariosController> _signInManager;

        public AccountController(UserManager<UsuariosController> userManager, SignInManager<UsuariosController> singInManager)
        {
            _userManager = userManager;
            _signInManager = singInManager;
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
                new Claim(JwtRegisteredClaimNames.)
            }
        }


    }
}