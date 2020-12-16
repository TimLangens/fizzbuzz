using System;

namespace Fizzbuzz.Demo.App.Models
{
    public class Timings
    {
        public Timings()
        {
            Start = DateTime.Now;           
        }
        public DateTime Start { get; set; }
        public DateTime? FirstResult { get; set; }
        public DateTime? End{ get; set; }

        public void Print()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"started at {Start}");
            Console.WriteLine($"ended at {End}");
            Console.WriteLine($"First result: {FirstResult}");
            Console.Write($"total duration: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{(End - Start)?.TotalSeconds}s");
            Console.ResetColor();
            Console.Write($"first result after: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{(FirstResult - Start)?.TotalSeconds}s");
            Console.ResetColor();
            Console.Write($"Paint duration: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{(End - FirstResult)?.TotalSeconds}s");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
