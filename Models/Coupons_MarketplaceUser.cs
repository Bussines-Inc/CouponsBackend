using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCupons.Models
{
    public class Coupons_MarketplaceUser
    {
        public int Id { get; set; }
        public int IdCoupon { get; set; }
        public int IdUserMarketPlace  { get; set; }
    }
}