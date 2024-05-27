using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Models;
using BackEndCupons.Services.Coupons;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCupons.Controllers.Coupons
{
    public class CouponsCreateController : ControllerBase
    {
        private readonly ICouponRepository _couponrepository;
        public CouponsCreateController(ICouponRepository couponrepository)
        {
            _couponrepository = couponrepository;
        }

        [HttpPost]
        [Route("api/coupons/create")]
        public IActionResult CreateCoupon ([FromBody] Coupon coupon)
        {
            try
            {   
                 _couponrepository.add(coupon);
                return Ok("Cupon creado con exito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}