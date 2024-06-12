using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCupons.Models
{
    public class MarketplaceUser
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        //public IList<Redemption> Redemption { get; set; }
    }
}