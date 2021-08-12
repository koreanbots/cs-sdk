using System;
using System.IO;

namespace BoringCodeWriting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] lines = File.ReadAllLines("C:\\Users\\arfon\\Documents\\cate.txt");
            foreach (var line in lines)
            {
                Console.WriteLine($"case \"{line}\":\nreturn;");
            }

            Console.ReadLine();
        }
    }
}
