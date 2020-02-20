using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Data.HashCode2020
{
    public class AllBooks
    {
        public Dictionary<Book, List<Library>> BooksPerLibary { get; set; } = new Dictionary<Book, List<Library>>();
    }
}
