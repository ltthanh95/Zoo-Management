using System;
using System.Collections.Generic;

namespace Zooe.Models
{
    public partial class ReportModelT
    {
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public int TicketId { get; set; }
        public float Price { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public sbyte IsValid { get; set; }
        public string linput { get; set; }
        public string rinput { get; set; }
    
    }
}
