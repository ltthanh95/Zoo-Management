using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class GiftShop
    {
        public GiftShop()
        {
            Items = new HashSet<Items>();
        }

        public int ShopId { get; set; }
        public int DepartmentId { get; set; }
        public string ShopName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
