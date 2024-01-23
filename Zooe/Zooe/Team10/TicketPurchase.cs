using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class TicketPurchase
    {
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public int TicketId { get; set; }
        public float Price { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public sbyte IsValid { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
