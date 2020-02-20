using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Data.HashCode2020
{
    public class GlobalData
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Library> Libraries { get; set; } = new List<Library>();
        public int NbdaysToScan { get; set; }
    }
}
