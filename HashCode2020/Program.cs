using System;
using System.IO;
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
                string calculated = ""; // compute(globalData)
                int score = new Scorer().getScore(globalData, calculated);
                Console.WriteLine($"Score sur le fichier {file} : {score}");
                globalScore += score;
            }

            Console.WriteLine($"Score global : {globalScore}");

            Console.ReadLine();
        }
    }
}
