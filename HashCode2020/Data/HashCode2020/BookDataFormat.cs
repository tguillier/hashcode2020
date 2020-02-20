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

        protected string GetDataFromLine(int line, int nb)
        {
            string[] lines = _rawData.Split("\n");
            return lines[line].Split(separator)[nb];
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
            AllBooks allBooks = new AllBooks();

            for (int i = 2; i<nbLibrairies*2 + 2; i = i+2)
            {
                int nbLibraryBooks = int.Parse(GetDataFromLine(i, 0));
                int signUpTime = int.Parse(GetDataFromLine(i, 1));
                int nbBooksPerDay = int.Parse(GetDataFromLine(i, 2));

                Library library = new Library();
                library.SignUpTime = signUpTime;
                library.NbBooksPerDay = nbBooksPerDay;

                for (int j=0; j < nbLibraryBooks; j++)
                {
                    Book bookToTake = books.ToArray()[int.Parse(GetDataFromLine(i + 1, j))];
                    library.Books.Add(bookToTake);
                }

                library.ScoreScan = library.Books.Sum(x => x.Score);
                library.NbDaysTotalScan = library.SignUpTime + (library.Books.Count / library.NbBooksPerDay);
                library.FullScanRatio = library.ScoreScan / library.NbDaysTotalScan;

                globalData.Libraries.Add(library);
                globalData.NbdaysToScan = nbDaysForScanning;
            }

            return globalData;
        }
    }
}
