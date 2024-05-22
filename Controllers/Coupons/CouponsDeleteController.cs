using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEndCupons.Services.Coupons;
using BackEndCupons.Models;

namespace BackEndCupons.Controllers.Coupons
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponsDeleteController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponsDeleteController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCoupon(int id, [FromBody] MarketingUser user)
        {
            try
            {
                _couponRepository.Remove(id, user.Id);
                return Ok(new { message = "Cupón eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(403, new { message = ex.Message });
            }
        }
    }

    // public class DeleteCouponRequest
    // {
    //     public int UserId { get; set; } // ID del usuario que realiza la solicitud
    // }
}
