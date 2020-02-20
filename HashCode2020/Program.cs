using System;
using System.IO;
using System.Linq;
using System.Text;
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
                string calculated = "2"; // compute

                int score = 0;// new Scorer().getScore(globalData, calculated);
                Console.WriteLine($"Score sur le fichier {file} : {score}");
                globalScore += score;

                try
                {
                    string fileName = $"C:\\Users\\nguidi\\Desktop\\Hashcode\\2020\\hashcode2020\\HashCode2020\\outputs\\{file.Split("\\").LastOrDefault()}";
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    // Create a new file     
                    using (FileStream fs = File.Create(fileName))
                    {
                        // Add some text to file    
                        Byte[] title = new UTF8Encoding(true).GetBytes(calculated);
                        fs.Write(title, 0, title.Length);
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
            }

            Console.WriteLine($"Score global : {globalScore}");

            Console.ReadLine();
        }
    }
}
