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
            coupon.Status = "Created";
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

            public void Update(Coupon coupon, int id, int Idmarketinguser)
            {

                var couponResult = _context.Coupon.FirstOrDefault(c => c.Id == id && c.IdMarketingUser == Idmarketinguser);

                if (couponResult != null)
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
