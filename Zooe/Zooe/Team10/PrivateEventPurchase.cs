using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class PrivateEventPurchase
    {
        public int TransactionId { get; set; }
        public int EventId { get; set; }
        public int CustomerId { get; set; }
        public int PassId { get; set; }
        public int TotalCost { get; set; }
        public DateTime PurchaseDate { get; set; }
        public sbyte IsValid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PrivateEvent Event { get; set; }
    }
}
