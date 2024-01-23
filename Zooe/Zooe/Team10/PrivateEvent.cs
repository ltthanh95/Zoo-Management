using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class PrivateEvent
    {
        public PrivateEvent()
        {
            PrivateEventPurchase = new HashSet<PrivateEventPurchase>();
        }

        public int EventId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime EventDate { get; set; }
        public float Price { get; set; }
        public int GuestCapacity { get; set; }
        public string Location { get; set; }
        public string EventType { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public sbyte IsBooked { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<PrivateEventPurchase> PrivateEventPurchase { get; set; }
    }
}
