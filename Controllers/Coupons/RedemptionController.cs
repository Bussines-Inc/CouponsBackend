using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Services.Coupons;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCupons.Controllers.Coupons
{
    public class RedemptionController : ControllerBase
    {
        private readonly ICouponRepository _couponrepository;
        public RedemptionController(ICouponRepository couponrepository)
        {
            _couponrepository = couponrepository;
        }

[HttpPost]
[Route("redemption/coupons")]
public async Task<IActionResult> Redemption(string couponCode, int idMarketplaceUser)
{
    try
    {
        var result = await _couponrepository.RedeemCoupon(couponCode, idMarketplaceUser);

                return result switch
                {
                    "Cliente no encontrado" => NotFound(result),
                    "Cupón no encontrado" => NotFound(result),
                    "Cupón ya ha sido usado" => BadRequest(result),
                    "Fecha de redención invalida" => BadRequest(result),
                    "Cupón no puede ser redimido" => BadRequest(result),
                    "Cupón redimido exitosamente" => Ok(result),
                    _ => StatusCode(500, result),// Mostrar el mensaje de error detallado
                };
            }
    catch (Exception ex)
    {
        // Manejo general de excepciones, opcionalmente puedes registrar el error
        return StatusCode(500, $"Error interno del servidor: {ex.Message}");
    }
}




    }
}