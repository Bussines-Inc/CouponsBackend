using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Models;

namespace BackEndCupons.Services.Coupons
{
    public interface ICouponRepository
    {
       IEnumerable<Coupon> GetAll();
       Coupon GetById(int id);
       IEnumerable<Coupon> GetAllByUser(int id);
       IEnumerable<Coupon> Search(); 
       void add(Coupon coupon);
       void remove(int id, int Idmarketinguser);
       void update(Coupon coupon, int id, int Idmarketinguser);
    }
}