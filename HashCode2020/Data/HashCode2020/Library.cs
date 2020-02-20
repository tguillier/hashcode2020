using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Data.HashCode2020
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public int SignUpTime { get; set; }
        public int NbBooksPerDay { get; set; }
        public int ScoreScan { get; set; }
        public int NbDaysTotalScan { get; set; }
        public int FullScanRatio { get; set; }

    }
}
