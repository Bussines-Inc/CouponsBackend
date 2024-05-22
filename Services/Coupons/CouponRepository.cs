using System;
using System.Collections.Generic;
using System.Linq;
using BackEndCupons.Data;
using BackEndCupons.Models;

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
            _context.Coupon.Add(coupon);
            _context.SaveChanges();
        }

        public IEnumerable<Coupon> GetAll()
        {
            return _context.Coupon.ToList();
        }

        public IEnumerable<Coupon> GetAllByUser(int id)
        {
            return _context.Coupon.Where(c => c.IdMarketingUser == id).ToList();
        }

        public Coupon GetById(int id)
        {
            return _context.Coupon.Find(id);
        }

        public void Remove(int id, int userId)
        {
            var coupon = _context.Coupon.FirstOrDefault(c => c.Id == id && c.IdMarketingUser == userId);

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

        public void Update(Coupon coupon, int id, int userId)
        {
            var existingCoupon = _context.Coupon.FirstOrDefault(c => c.Id == id && c.IdMarketingUser == userId);

            if (existingCoupon != null)
            {
                existingCoupon.CouponCode = coupon.CouponCode;
                existingCoupon.Description = coupon.Description;
                existingCoupon.CreationDate = coupon.CreationDate;
                existingCoupon.StartDate = coupon.StartDate;
                existingCoupon.ExpirationDate = coupon.ExpirationDate;
                existingCoupon.Status = coupon.Status;
                existingCoupon.DiscountRate = coupon.DiscountRate;
                existingCoupon.DiscountValue = coupon.DiscountValue;
                existingCoupon.LimitType = coupon.LimitType;
                existingCoupon.MaximumUses = coupon.MaximumUses;
                existingCoupon.MinimumPurchaseAmount = coupon.MinimumPurchaseAmount;
                existingCoupon.MaximumDiscountAmount = coupon.MaximumDiscountAmount;
                existingCoupon.IdMarketingUser = coupon.IdMarketingUser;

                _context.Coupon.Update(existingCoupon);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Cupón no encontrado o no tienes permiso para actualizarlo");
            }
        }
    }
}
