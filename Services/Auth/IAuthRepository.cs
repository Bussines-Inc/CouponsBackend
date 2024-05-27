using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCupons.Services.Auth
{
    public interface IAuthRepository
    {
        MarketingUser Login(string Username, string Password);
        string GenerateToken (MarketingUser User);
        void LogOutAsync();
        IEnumerable<MarketingUser> GetAll();
    }

}