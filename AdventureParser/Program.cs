using System;
using System.IO;
using AdventureParser.ParserCore;

namespace AdventureParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            string gameFile = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gameDemo.json"));
            parser.LoadFile(gameFile);
            parser.Test();
            //while (true)
            //{
            //    //string input = Console.ReadLine();
            //    //Console.WriteLine(input);
            //}
        }
    }
}
