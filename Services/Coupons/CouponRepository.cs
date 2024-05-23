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
            var cupons = _context.Coupon.Where(c=>c.IdMarketingUser==id).ToList();
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
            var cupon = _context.Coupon.FirstOrDefault(c=>c.Id == id && c.IdMarketingUser == Idmarketinguser);
            _context.Coupon.Update(coupon);
            _context.SaveChanges();
        }
    }
}