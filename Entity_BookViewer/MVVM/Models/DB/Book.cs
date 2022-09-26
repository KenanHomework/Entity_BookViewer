using Entity_BookViewer.Interfaces;
using System;
using System.Collections.Generic;

namespace Entity_BookViewer
{
    public partial class Book:IHaveForeigneID
    {
        public Book()
        {
            SCards = new HashSet<SCard>();
            TCards = new HashSet<TCard>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public int IdThemes { get; set; }
        public int IdCategory { get; set; }
        public int IdAuthor { get; set; }
        public int IdPress { get; set; }
        public string? Comment { get; set; }
        public int Quantity { get; set; }

        public virtual Author IdAuthorNavigation { get; set; } = null!;
        public virtual Category IdCategoryNavigation { get; set; } = null!;
        public virtual Press IdPressNavigation { get; set; } = null!;
        public virtual Theme IdThemesNavigation { get; set; } = null!;
        public virtual ICollection<SCard> SCards { get; set; }
        public virtual ICollection<TCard> TCards { get; set; }

        public bool IdIsMatched(object item)
        {
            if (item is Author author) return this.IdAuthor == author.Id;
            else if (item is Category category) return this.IdAuthor == category.Id;
            else if (item is Theme theme) return this.IdAuthor == theme.Id;
            else if (item is Press press) return this.IdAuthor == press.Id;
            return false;
        }

        public override string ToString() => $"{Name}";

    }
}
