using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Services.Coupons;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCupons.Controllers.Coupons
{
    public class CouponsDeleteController : ControllerBase
    {
        private readonly ICouponRepository _couponrepository;
        public CouponsDeleteController(ICouponRepository couponrepository)
        {
            _couponrepository = couponrepository;
        }
    }
}