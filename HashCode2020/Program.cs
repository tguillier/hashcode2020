using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HashCode2020.Data.HashCode2020;

namespace HashCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("Data\\inputs");

            int globalScore = 0;
            
            foreach(string file in files)
            {
                string rawData = File.ReadAllText(file);
                BookDataFormat bdf = new BookDataFormat(rawData);
                var globalData = bdf.CreateFromRawData();
                string calculated = GetResult(globalData); // compute(globalData)
                int score = new Scorer().getScore(globalData, calculated);
                Console.WriteLine($"Score sur le fichier {file} : {score}");
                globalScore += score;
            }

            Console.WriteLine($"Score global : {globalScore}");

            Console.ReadLine();
        }

        private static string GetResult(GlobalData dataset)
        {
            var submission = new Submission();

            dataset.Libraries = dataset.Libraries.OrderByDescending(l => l.SignUpTime).ThenBy(l => l.NbBooksPerDay).ToList();
            int libraryIndex = 0;

            var library = dataset.Libraries.ElementAt(libraryIndex);
            submission.Libraries.Add(new LibraryForSub
            {
                Id = library.Id,
                SignUpTime = library.SignUpTime,
                NbBooksPerDay = library.NbBooksPerDay,
                SignupStartDay = 0
            });

            var signupTimeSum = library.SignUpTime;

            for (int day = 0; day < dataset.NbdaysToScan; day++)
            {
                if (day >= signupTimeSum)
                {
                    libraryIndex++;
                    if (libraryIndex >= dataset.Libraries.Count())
                    {
                        ScanBooksInSignedUpLibrary(submission, day);
                        continue;
                    }

                    library = dataset.Libraries.Skip(libraryIndex).FirstOrDefault(l => l.SignUpTime < dataset.NbdaysToScan - day);
                    if (library is null)
                    {
                        ScanBooksInSignedUpLibrary(submission, day);
                        continue;
                    }

                    submission.Libraries.Add(new LibraryForSub
                    {
                        Id = library.Id,
                        SignUpTime = library.SignUpTime,
                        NbBooksPerDay = library.NbBooksPerDay,
                        SignupStartDay = day
                    });

                    signupTimeSum += library.SignUpTime;
                }

                // Scan books
                ScanBooksInSignedUpLibrary(submission, day);
            }

            void ScanBooksInSignedUpLibrary(Submission sub, int day)
            {
                foreach (var l in sub.Libraries)
                {
                    if (day >= l.SignUpTime + l.SignupStartDay)
                    {
                        ScanBooksInLibrary(l, day);
                    }
                }
            }

            void ScanBooksInLibrary(LibraryForSub libraryForSub, int day)
            {
                for (int i = 0; i < libraryForSub.NbBooksPerDay; i++)
                {
                    KeyValuePair<int, Book> maximumScoreBook;
                    try
                    {
                        maximumScoreBook = dataset.Libraries.ElementAt(libraryForSub.Id).Books.OrderByDescending(b => b.Value.Score).First(b => !b.Value.IsScanned);
                    }
                    catch (Exception)
                    {
                        try
                        {

                            maximumScoreBook = dataset.Libraries.ElementAt(libraryForSub.Id).Books.First(b => !libraryForSub.Books.Any(b2 => b2.Id == b.Key));
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }



                    libraryForSub.Books.Add(new BookForSub
                    {
                        Id = maximumScoreBook.Key
                    });

                    maximumScoreBook.Value.IsScanned = true;
                }
            }

            string submissionFile = submission.Libraries.Count().ToString() + "\n";
            foreach (var lib in submission.Libraries)
            {
                submissionFile += lib.Id + " " + lib.Books.Count().ToString() + "\n";
                submissionFile += string.Join(" ", lib.Books.Select(b => b.Id)) + "\n";
            }

            return submissionFile.Substring(0, submissionFile.Length - 2);
        }
    }

    public class Submission
    {
        public List<LibraryForSub> Libraries { get; set; } = new List<LibraryForSub>();
    }

    public class LibraryForSub
    {
        public int Id { get; set; }
        public int SignUpTime { get; set; }
        public int NbBooksPerDay { get; set; }
        public int SignupStartDay { get; set; }
        public List<BookForSub> Books { get; set; } = new List<BookForSub>();
    }

    public class BookForSub
    {
        public int Id { get; set; }
    }
}
