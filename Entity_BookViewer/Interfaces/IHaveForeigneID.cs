using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_BookViewer.Interfaces
{
    public interface IHaveForeigneID
    {
        public bool IdIsMatched(object item);
    }
}
