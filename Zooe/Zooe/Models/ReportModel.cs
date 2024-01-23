using System;
using System.Collections.Generic;

namespace Zooe.Models
{
    public partial class ReportModel
    {
        public int TransactionId { get; set; }
        public int ItemId { get; set; }
        public int CustomerId { get; set; }
        public float TotalCost { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public string linput { get; set; }
        public string rinput { get; set; }

    }
}
