using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Models;
using BackEndCupons.Services.Coupons;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCupons.Controllers.Coupons
{
    public class CouponsEditController : ControllerBase
    {
         private readonly ICouponRepository _couponrepository;
        public CouponsEditController(ICouponRepository couponrepository)
        {
            _couponrepository = couponrepository;
        }
        
        [HttpPut]
        [Route("api/coupons")]
        public IActionResult UpdateCoupons([FromQuery] int id, int idMarketingUser, [FromBody] Coupon coupon)
        {
           try
           {
                _couponrepository.Update(coupon, id, idMarketingUser);
                return Ok("Cupon actualizado con exito");
           }
           catch(Exception e)
           {
               return StatusCode(403, new{e.Message});
           }
        }
    }
}