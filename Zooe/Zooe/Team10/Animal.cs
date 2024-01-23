using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class Animal
    {
        public int AnimalId { get; set; }
        public int ExhibitId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime LastCheckup { get; set; }
        public decimal Weight { get; set; }
        public sbyte Gender { get; set; }
        public string ShortDescription { get; set; }

        public virtual Exhibit Exhibit { get; set; }
    }
}
