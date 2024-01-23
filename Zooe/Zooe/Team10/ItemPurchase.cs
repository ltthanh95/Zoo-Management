using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class ItemPurchase
    {
        public int TransactionId { get; set; }
        public int ItemId { get; set; }
        public int CustomerId { get; set; }
        public float TotalCost { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Items Item { get; set; }
       
    }
}
