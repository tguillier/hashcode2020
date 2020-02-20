using System;
using HashCode2020.Data.HashCode2020;

namespace HashCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            // File reading
            //string rawData = System.IO.File.ReadAllText(args[0]);
            //string rawData = System.IO.File.ReadAllText("Data\\inputs\\f_libraries_of_the_world.txt");
            string rawData = System.IO.File.ReadAllText("Data\\inputs\\a_example.txt");

            // Converting in usable data
            BookDataFormat bdf = new BookDataFormat(rawData);
            var p = bdf.CreateFromRawData();
            Console.ReadLine();
        }
    }
}
