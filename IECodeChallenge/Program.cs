using System;

namespace IECodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                Console.WriteLine("Accepted");
            }

            Console.Write("Ok bye");
        }
    }
}
