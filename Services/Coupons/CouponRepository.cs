using System;
using System.Collections.Generic;
using System.Linq;
using BackEndCupons.Data;
using BackEndCupons.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndCupons.Services.Coupons
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CouponsContext _context;

        public CouponRepository(CouponsContext context)
        {
            _context = context;
        }

        public void Add(Coupon coupon)
        {

            coupon.Status = "Created";
            coupon.amount_uses = 0;
            coupon.CreationDate = DateTime.UtcNow;

            _context.Coupon.Add(coupon);
            _context.SaveChanges();
        }

        public IEnumerable<Coupon> GetAll()
        {
            var cupon = _context.Coupon.ToList();
            return cupon;
            // if (cupon != null)
            // {
            //     return _context.Coupon.ToList();            
            // }
            // else
            // {
            //     throw new Exception("Cupónes no encontrado ");
            // }
        }

        public IEnumerable<Coupon> GetAllByUser(int id)
        {
            var cupons = _context.Coupon.Where(c => c.IdMarketingUser == id).ToList();
            return cupons;
        }

        public Coupon GetById(int id)

        {
            var cupon = _context.Coupon.Find(id);
            if (cupon != null)
            {
                return cupon;
            }
            else
            {
                throw new Exception("Cupon no encontrado");
            }
        }


        public async Task<string> RedeemCoupon(string couponcode, int idMarketplaceUser)
        {
            try
            {
                // Validar que el usuario existe
                var user = await _context.MarketingUser.FirstOrDefaultAsync(client => client.Id == idMarketplaceUser);
                if (user == null)
                {
                    return "Cliente no encontrado";
                }
                
          
                // Buscar el cupón
                var cupon = await _context.Coupon.FirstOrDefaultAsync(cp=>cp.CouponCode.Equals(couponcode));
                if (cupon == null)
                {
                    return "Cupón no encontrado";
                }

                // Verificar si el cupón ya fue usado por ese cliente
                //var redencion = await _context.Redemption.Include(r=>r.MarketplaceUser).FirstOrDefaultAsync(rede => rede.IdMarketplaceUser == idMarketplaceUser && rede.IdCoupon == cupon.Id);
                
                var redencion = await _context.Redemption.FirstOrDefaultAsync(rede => rede.IdMarketplaceUser == idMarketplaceUser && rede.IdCoupon == cupon.Id);
                if (redencion != null)
                {
                    return "Cupón ya ha sido usado";
                }

                var currentDate = DateTime.UtcNow;
                if (currentDate < cupon.StartDate || currentDate > cupon.ExpirationDate)
                {
                    return "Fecha de redención invalida";
                }
                // Verificar la validez del cupón
                if (cupon.Status != "Active")
                {
                    return "Cupón no puede ser redimido";
                }

                // Incrementar contadores de uso
                if (cupon.MaximumUses > 0)
                {
                    cupon.MaximumUses--;
                }
                if (cupon.LimitType == "Limit")
                {
                    cupon.amount_uses++;
                }

                // Guardar la redención
                var redemptionCoupon = new Redemption
                {
                    UseDate = DateTime.UtcNow,
                    Price = 10,
                    Status = "Used",
                    PurchaseId = 0,
                    IdCoupon = cupon.Id,
                    IdMarketplaceUser = user.Id
                };
                _context.Redemption.Add(redemptionCoupon);
                await _context.SaveChangesAsync();

                return "Cupón redimido exitosamente";
            }
            catch (Exception ex)
            {
                // Registro del error para depuración
                return $"Erro interno del servidor: {ex.Message}";
            }
        }

        public void Remove(int id, int userId)
        {
            var coupon = _context.Coupon.FirstOrDefault(c => c.Id == id && c.IdMarketingUser == userId && c.amount_uses == 0);

            if (coupon == null)
            {
                throw new Exception("Cupón no encontrado o no tienes permiso para eliminarlo");
            }

            _context.Coupon.Remove(coupon);
            _context.SaveChanges();
        }

        public IEnumerable<Coupon> Search()
        {
            throw new NotImplementedException();
        }

        public void Update(Coupon coupon, int id, int Idmarketinguser)
        {

            var couponResult = _context.Coupon.FirstOrDefault(c => c.Id == id && c.IdMarketingUser == Idmarketinguser);

            if (couponResult != null)
            {
                couponResult.CouponCode = coupon.CouponCode;
                couponResult.Description = coupon.Description;
                couponResult.StartDate = coupon.StartDate;
                couponResult.ExpirationDate = coupon.ExpirationDate;
                couponResult.Status = coupon.Status;
                couponResult.DiscountRate = coupon.DiscountRate;
                couponResult.DiscountValue = coupon.DiscountValue;
                couponResult.LimitType = coupon.LimitType;
                couponResult.MaximumUses = coupon.MaximumUses;
                couponResult.MinimumPurchaseAmount = coupon.MinimumPurchaseAmount;
                couponResult.MaximumDiscountAmount = coupon.MaximumDiscountAmount;

                _context.Coupon.Update(couponResult);
                _context.SaveChanges();
            }

            else
            {
                throw new Exception("Cupón no encontrado o no tienes permiso para editarlo");
            }

        }
    }
}

//  if (couponResult.ammount_uses < couponResult.MaximumUses)
//                 {
//                     couponResult.ammount_uses++;
//                     couponResult.Status = "Used";
//                     _context.Coupon.Update(couponResult);
//                     _context.SaveChanges();
//                 }
//                 else
//                 {
//                     throw new Exception("Cupón no disponible");
//                 }