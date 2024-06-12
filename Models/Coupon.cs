using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BackEndCupons.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public string Description { get; set; }
        public int ammount_uses { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }
        [Required]
        public string DiscountRate { get; set; }
        [Required]
        public int DiscountValue { get; set; }
        [Required]
        public string LimitType { get; set; }
        [Required]
        public int? MaximumUses { get; set; }
        [Required]
        public int? MinimumPurchaseAmount { get; set; }
        [Required]
        public int? MaximumDiscountAmount { get; set; }
        [Required]
        public int IdMarketingUser { get; set;}
        public ICollection<Coupons_MarketplaceUser> Coupons_MarketplaceUser { get; set; }
    }
}
