using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Data;
using BackEndCupons.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BackEndCupons.Services.Coupons
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CouponsContext  _context;
        public CouponRepository(CouponsContext context)
        {
            _context = context;
        }
        public void add(Coupon coupon)
        {

            coupon.Status = "Created";
            coupon.CreationDate = DateTime.UtcNow;

            _context.Coupon.Add(coupon);
            _context.SaveChanges();
        }

        public IEnumerable<Coupon> GetAll()
        {
            return _context.Coupon.ToList();            
        }

        public IEnumerable<Coupon> GetAllByUser(int id)
        {
            var cupons = _context.Coupon.Where(c=>c.IdMarketingUser==id);
            return cupons.ToList();
        }

        public Coupon GetById(int id)
        {
            return _context.Coupon.Find(id);
        }

        public void remove(int id, int Idmarketinguser)
        {
            var cupon= _context.Coupon.FirstOrDefault(c=>c.Id == id && c.IdMarketingUser == Idmarketinguser);
            
            if(cupon != null)
            {
                _context.Coupon.Remove(cupon);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Cupón no encontrado");
            }   
        }

        public IEnumerable<Coupon> Search()
        {
            throw new NotImplementedException();
        }

        public void update(Coupon coupon, int id, int Idmarketinguser)
        {
            var couponResult = _context.Coupon.FirstOrDefault(c=>c.Id == id && c.IdMarketingUser == Idmarketinguser);

            if(couponResult != null)
            {
                couponResult.CouponCode = coupon.CouponCode;
                couponResult.Description = coupon.Description;
                couponResult.StartDate = coupon.StartDate;
                couponResult.ExpirationDate = coupon.ExpirationDate;
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