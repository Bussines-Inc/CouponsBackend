using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Data;

namespace BackEndCupons.Services.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CouponsContext  _context;
        public AuthRepository(CouponsContext context)
        {
            _context = context;
        }
        public Task LoginAsyn(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task LogOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}