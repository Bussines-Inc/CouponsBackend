using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCupons.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }
        public string DiscountRate { get; set; }
        public int DiscountValue { get; set; }
        public string LimitType { get; set; }
        public int? MaximumUses { get; set; }
        public int? MinimumPurchaseAmount { get; set; }
        public int? MaximumDiscountAmount { get; set; }
        public int IdMarketingUser { get; set;}
    }
}