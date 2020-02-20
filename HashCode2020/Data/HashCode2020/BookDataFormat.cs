using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCode2020.Data.HashCode2020
{
    public class BookDataFormat
    {
        string _rawData;
        public readonly string separator = " ";

        public BookDataFormat(string rawData)
        {
            _rawData = rawData;
        }

        protected int GetDataFromLine(int line, int nb)
        {
            string[] lines = _rawData.Split("\n");
            return int.Parse(lines[line].Split(separator)[nb]);
        }

        public GlobalData CreateFromRawData()
        {
            GlobalData globalData = new GlobalData();

            string firstLine = _rawData.Split("\n")[0];
            string[] infosFirstLine = firstLine.Split(separator);
            int nbBooks = int.Parse(infosFirstLine[0]);
            int nbLibrairies = int.Parse(infosFirstLine[1]);
            int nbDaysForScanning = int.Parse(infosFirstLine[2]);

            string secondLine = _rawData.Split("\n")[1];
            string[] infosSecondLine = secondLine.Split(separator);
            List<Book> books = new List<Book>();
            foreach (string bookScore in infosSecondLine)
            {
                books.Add(new Book { Score = int.Parse(bookScore) });
            }

            List<Library> librairies = new List<Library>();

            for (int i = 2; i < nbLibrairies * 2 + 2; i = i + 2)
            {
                string line1 = _rawData.Split("\n")[i];
                string[] line1Array = line1.Split(separator);
                string line2 = _rawData.Split("\n")[i + 1];
                string[] line2Array = line2.Split(separator);

                int nbLibraryBooks = int.Parse(line1Array[0]);
                int signUpTime = int.Parse(line1Array[1]);
                int nbBooksPerDay = int.Parse(line1Array[2]);

                Library library = new Library();
                library.SignUpTime = signUpTime;
                library.NbBooksPerDay = nbBooksPerDay;

                for (int j=0; j < nbLibraryBooks; j++)
                {
                    library.Books.Add(j, books.ElementAt(int.Parse(line2Array[j])));
                }

                library.ScoreScan = library.Books.Select(b => b.Value).Sum(x => x.Score);
                library.NbDaysTotalScan = library.SignUpTime + (library.Books.Count / library.NbBooksPerDay);
                library.FullScanRatio = library.ScoreScan / library.NbDaysTotalScan;

                globalData.Libraries.Add(library);
                globalData.NbdaysToScan = nbDaysForScanning;
                globalData.Books = books;
            }

            return globalData;
        }
    }
}
