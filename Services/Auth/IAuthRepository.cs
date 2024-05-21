using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCupons.Services.Auth
{
    public interface IAuthRepository
    {
        Task LoginAsyn(string username, string password);
        Task LogOutAsync();
    }

}