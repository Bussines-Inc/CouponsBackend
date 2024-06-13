using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Models;
using BackEndCupons.Services.Coupons;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCupons.Controllers.Coupons
{
    public class CouponsController : ControllerBase
    {
        private readonly ICouponRepository _couponrepository;
        public CouponsController(ICouponRepository couponrepository)
        {
            _couponrepository = couponrepository;
        }

        [HttpGet]
        [Route("api/Coupons")]
        public IActionResult GetCoupons()
        {
            try
            {
                var coupons = _couponrepository.GetAll();
                if (coupons.Count() <1)
                {
                    return BadRequest("No existen cupones");
                }
                else
                {
                    return Ok(coupons);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(203, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Coupons/{id}")]
        public IActionResult Details(int id)
        {
            try
            {
                var coupons = _couponrepository.GetById(id);
                if (coupons == null){
                        return StatusCode(404, "Cupón no encontrado");
                }
                else{
                    return Ok(coupons);
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/MyCoupons/{id}")]
        public IActionResult GetAllByUser(int id)
        {
        
             try
            {
                var cupones = _couponrepository.GetAllByUser(id);
                 if(cupones.Count() < 1){
                    return BadRequest("No tienes cupones");
                 }else{
                    return Ok(cupones);
                 }
            }
            catch (Exception ex)
            {
                return StatusCode(203,ex.Message);
            }
        }

    }
}