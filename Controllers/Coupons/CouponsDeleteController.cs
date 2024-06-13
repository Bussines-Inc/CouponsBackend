using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEndCupons.Services.Coupons;
using BackEndCupons.Models;

namespace BackEndCupons.Controllers.Coupons
{
    public class CouponsDeleteController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponsDeleteController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpDelete]
        [Route("api/DeleteCoupon/{id}/{idMarketingUser}")]

        public IActionResult DeleteCoupon(int id, int idMarketingUser)
        {
            try
            {
                var coupon = _couponRepository.GetById(id);
                if (coupon != null && coupon.IdMarketingUser ==  idMarketingUser)
                {
                    _couponRepository.Remove(id, idMarketingUser);
                    return Ok(new { message = "Cupón eliminado con éxito" });
                }
                else
                {
                    return BadRequest("No tienes permiso de eliminarlo");
                }
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
