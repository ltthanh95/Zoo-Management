using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class Staff
    {
        public int StaffId { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public float Salary { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Department Department { get; set; }
    }
}
