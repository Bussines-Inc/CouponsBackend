using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCupons.Models
{
    public class Redemption
    {
        public int Id { get; set; }
        public DateTime UseDate { get; set; }
        public int Price { get; set;}
        public string Status { get; set; }
        public int PurchaseId { get; set; }
        public int 	IdCoupon { get; set; }
        public int 	IdMarketplaceUser { get; set; }
        // public Coupon Coupon { get; set; }
        // public Coupons_MarketplaceUser Coupons_MarketplaceUser { get; set;}
        //public MarketplaceUser MarketplaceUser { get; set;}

    }
}