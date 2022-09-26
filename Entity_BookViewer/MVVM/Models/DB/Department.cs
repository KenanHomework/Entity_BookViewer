using System;
using System.Collections.Generic;

namespace Entity_BookViewer
{
    public partial class Department
    {
        public Department()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
