using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Models;
using BackEndCupons.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BackEndCupons.Controllers.Auth
{

    public class AuthLoginController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthLoginController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        // public IActionResult Login ([FromBody]UserCred userCred)
        // {
        //    var p =  _authRepository.LoginAsyn(userCred.username, userCred.password);
        // }

        [HttpPost]
        [Route("api/login")]
        public IActionResult LoginUser ([FromBody] UserCred usercred)
        {
            try 
            {
                var user = _authRepository.Login(usercred.username, usercred.password);
                if (user == null)
                {
                    return Unauthorized("Credenciales invalidas");
                }

                var tokenString = _authRepository.GenerateToken(user);
                return Ok(new { token = tokenString });
            }
            catch (Exception e)
            {
                return BadRequest("Error al ingresar"+e);
            }
        }

    //data notation request
        
    }
}