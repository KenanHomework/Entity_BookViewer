using System;
using System.Collections.Generic;

namespace Entity_BookViewer
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
