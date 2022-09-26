using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_BookViewer.Extensions
{
    public static class ListExtension
    {

        public static List<string> ToStringItems(this List<object> list) => list.Select(x => x.ToString()).ToList();

    }
}
