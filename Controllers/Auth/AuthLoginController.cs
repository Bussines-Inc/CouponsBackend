using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCupons.Controllers.Auth
{
    public class AuthLoginController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthLoginController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        
    }
}