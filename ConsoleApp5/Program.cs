using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            string Item = Console.ReadLine();
            Console.OutputEncoding = System.Text.Encoding.ASCII;
            Console.WriteLine(Item);
            
        }
    }
}
