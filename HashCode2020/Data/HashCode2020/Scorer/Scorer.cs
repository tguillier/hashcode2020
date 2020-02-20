using HashCode2020.Data.HashCode2020;
using HashCode2020.Data.HashCode2020.Scorer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode2020
{
    class Scorer
    {
        int getScore(GlobalData globalData, string submissionContent)
        {
            GlobalSubmission submission = parseSubmissionFile(globalData, submissionContent);

            var totalScore = 0;
            var day = 0;
            foreach (var libId in submission.librariesToScan)
            {
                var lib = globalData.Libraries[libId.libraryId];
                if (day + lib.SignUpTime >= globalData.NbdaysToScan)
                    return totalScore;

            }

                return totalScore;
        }

        GlobalSubmission parseSubmissionFile(GlobalData globalData, string submissionContent)
        {
            GlobalSubmission submission = new GlobalSubmission();

            List<string> lines = submissionContent.Split('\n').ToList();

            submission.nbLibrariesToScan = int.Parse(lines[0]);
            lines.RemoveAt(0);

            submission.librariesToScan = new List<LibraryToScan>();
            while (lines.Count > 0)
            {
                string[] libLine = lines[0].Split(' ');
                string[] booksLine = lines[1].Split(' ');

                var libToScan = new LibraryToScan();

                libToScan.libraryId = int.Parse(libLine[0]);

                var nbBooks = int.Parse(libLine[1]);
                if (nbBooks != booksLine.Count())
                    throw new Exception($"Invalid format : Library [{libToScan.libraryId}] should contain {nbBooks} books but the list on the next line contains {booksLine.Count()} items.");

                libToScan.booksToScan = new List<int>(booksLine.Select(i => int.Parse(i)));

                if (libToScan.libraryId < 0 || libToScan.libraryId > globalData.Libraries.Count() - 1)
                    throw new Exception($"Library {libToScan.libraryId} doesnt exist");

                var realLibrary = globalData.Libraries[libToScan.libraryId];
                libToScan.booksToScan.ForEach(book =>
                {
                    if (realLibrary.Books.Count(b => b.Score == book) != 1)
                        throw new Exception($"Actual library with id {libToScan.libraryId} doesnt have a book with score {book}");
                });

                submission.librariesToScan.Add(libToScan);
                lines.RemoveRange(0, 2);
            }

            if (submission.nbLibrariesToScan != submission.librariesToScan.Count())
                throw new Exception($"Invalid number of libraries. File annonces {submission.nbLibrariesToScan} on first line but found {submission.librariesToScan.Count()}");

            return submission;
        }

    }
    // day 0
    // signup 2
    // nbdays 3
}
