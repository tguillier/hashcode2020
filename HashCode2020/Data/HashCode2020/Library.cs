using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Data.HashCode2020
{
    public class Library
    {
        public Dictionary<int, Book> Books { get; set; } = new Dictionary<int, Book>();
        public int SignUpTime { get; set; }
        public int NbBooksPerDay { get; set; }
        public int ScoreScan { get; set; }
        public int NbDaysTotalScan { get; set; }
        public int FullScanRatio { get; set; }

    }
}
