using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCupons.Services.Redemption
{
    public interface IRedemptionRepository
    {
        Task ValidationsAsync();
        Task RedeemAsync();
    }
}