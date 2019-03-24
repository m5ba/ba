using System;
using System.Collections.Generic;

namespace Basicalgorithm.Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Let's count.");
            IDictionary<int, string> dict = new DictionaryMd<int, string>(100);
            dict[9]="nine";
            dict.Add(8, "eight");
            Console.WriteLine($"{dict[9]}");
            Console.WriteLine($"{dict[8]}");
            dict[9]="NINE";
            Console.WriteLine($"{dict[9]}");
            Console.WriteLine($"{dict[8]}");
            try{
                dict.Add(9, "akward");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception: \n   '{e.GetType()}'\n   '{e.Message}'");
            }
            Console.WriteLine("Goodbye...");
        }
    }
}
