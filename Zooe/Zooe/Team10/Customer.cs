using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class Customer
    {
        public Customer()
        {
            ItemPurchase = new HashSet<ItemPurchase>();
            PrivateEventPurchase = new HashSet<PrivateEventPurchase>();
            TicketPurchase = new HashSet<TicketPurchase>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StreetName { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<ItemPurchase> ItemPurchase { get; set; }
        public virtual ICollection<PrivateEventPurchase> PrivateEventPurchase { get; set; }
        public virtual ICollection<TicketPurchase> TicketPurchase { get; set; }
    }
}
