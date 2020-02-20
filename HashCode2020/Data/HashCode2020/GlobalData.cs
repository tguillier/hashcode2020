using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Data.HashCode2020
{
    public class GlobalData
    {
        public AllBooks AllBooks { get; set; }
        public List<Library> Libraries { get; set; } = new List<Library>();
        public int NbdaysToScan { get; set; }
    }
}
