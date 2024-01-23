using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class Items
    {
        public Items()
        {
            ItemPurchase = new HashSet<ItemPurchase>();
        }

        public int ItemId { get; set; }
        public int ShopId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public int StockCount { get; set; }

        public virtual GiftShop Shop { get; set; }
        public virtual ICollection<ItemPurchase> ItemPurchase { get; set; }
    }
}
