using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCupons.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndCupons.Data
{
    public class CouponsContext : DbContext
    {
        public CouponsContext(DbContextOptions<CouponsContext> options): base(options)
        {

        }

        public DbSet<Coupons_MarketplaceUser>Coupons_MarketplaceUser { get; set; }
        public DbSet<Coupon> Coupon{ get; set; }
        public DbSet<MarketingUser>MarketingUser { get; set; }
        public DbSet<MarketplaceUser>MarketplaceUser { get; set; }
        public DbSet<Redemption>Redemption { get; set; }

    }
}