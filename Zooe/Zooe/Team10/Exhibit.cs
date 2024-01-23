using System;
using System.Collections.Generic;

namespace Zooe.Team10
{
    public partial class Exhibit
    {
        public Exhibit()
        {
            Animal = new HashSet<Animal>();
        }

        public int ExhibitId { get; set; }
        public int DepartmentId { get; set; }
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string ExhibitHabitat { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Animal> Animal { get; set; }
    }
}
