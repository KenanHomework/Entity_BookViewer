using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_BookViewer.Extensions
{
    public static class StringExtension
    {
        public static string ReverseString(this string obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string str = obj.ToString();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                stringBuilder.Append(str[i]);
            }
            return stringBuilder.ToString();
        }

    }
}
