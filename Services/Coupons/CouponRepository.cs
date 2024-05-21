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
            var cupon = _context.Coupon.FirstOrDefault(c=>c.Id == id && c.IdMarketingUser == Idmarketinguser);
            _context.Coupon.Update(coupon);
            _context.SaveChanges();
        }
    }
}