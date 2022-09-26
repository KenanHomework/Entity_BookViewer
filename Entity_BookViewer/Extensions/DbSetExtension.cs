using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_BookViewer.Extensions
{
    public static class DbSetExtension
    {
        public static string GetObjectName(this object obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string str = obj.ToString();
            for (int i = str.Length - 2; i > 0; i--)
            {
                if (str[i] == '.') return stringBuilder.ToString().ReverseString();
                stringBuilder.Append(str[i]);
            }
            return stringBuilder.ToString().ReverseString();
        }

        public static List<Book> GetMathedItems(this DbSet<Book> books, object item) => (from book in books.ToList()
                                                                                         where book.IdIsMatched(item)
                                                                                         select book).ToList();

        public static List<string> ToObjectNames(this List<object> dbSet)
        {
            List<string> list = new();
            list.AddRange(dbSet.Select(item => item.GetObjectName()));
            return list;
        }

    }
}
