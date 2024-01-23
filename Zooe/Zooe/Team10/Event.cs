using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class Event
    {
        public int EventId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public virtual Department Department { get; set; }
    }
}
