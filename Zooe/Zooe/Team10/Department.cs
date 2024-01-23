using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class Department
    {
        public Department()
        {
            Event = new HashSet<Event>();
            Exhibit = new HashSet<Exhibit>();
            GiftShop = new HashSet<GiftShop>();
            PrivateEvent = new HashSet<PrivateEvent>();
            Staff = new HashSet<Staff>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Exhibit> Exhibit { get; set; }
        public virtual ICollection<GiftShop> GiftShop { get; set; }
        public virtual ICollection<PrivateEvent> PrivateEvent { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
