using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Data.HashCode2020.Scorer
{
    class GlobalSubmission
    {
        public int nbLibrariesToScan { get; set; }

        public List<LibraryToScan> librariesToScan { get; set; }
    }

    class LibraryToScan
    {
        public int libraryId { get; set; }

        public List<int> booksToScan { get; set; }
    }
}
