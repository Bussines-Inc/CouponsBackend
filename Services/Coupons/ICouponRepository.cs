using System.Collections.Generic;
using BackEndCupons.Models;

namespace BackEndCupons.Services.Coupons
{
    public interface ICouponRepository
    {
        IEnumerable<Coupon> GetAll();
        Coupon GetById(int id);
        IEnumerable<Coupon> GetAllByUser(int id);
        IEnumerable<Coupon> Search(); 
        void Add(Coupon coupon);
        void Remove(int id, int userId);  // Modificado para incluir el ID del usuario
        void Update(Coupon coupon, int id, int userId);
    }
}
