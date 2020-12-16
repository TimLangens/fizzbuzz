using Fizzbuzz.Demo.App.Models;
using Fizzbuzz.Demo.App.Services;
using System;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine();
            Console.WriteLine("  ╔═╗╦╔═╗╔═╗  ╔╗ ╦ ╦╔═╗╔═╗");
            Console.WriteLine("  ╠╣ ║╔═╝╔═╝  ╠╩╗║ ║╔═╝╔═╝");
            Console.WriteLine("  ╚  ╩╚═╝╚═╝  ╚═╝╚═╝╚═╝╚═╝");
            Console.WriteLine();
            while (Console.ReadKey().Key != ConsoleKey.Q) 
            {
                Console.WriteLine("Type of call (Monolith/rest/grpc): ");
                await StartFizzBuzz(Console.ReadLine());
            } 
        }

        private static async Task StartFizzBuzz(string type)
        {
            switch (type)
            {
                case "rest":
                    Console.WriteLine("--- REST CALL STARTED ---");
                    await Run(new RestFizzService(), new RestBuzzService(), new RestNumberService());
                    Console.WriteLine("--- REST CALL ENDED ---");
                    break;
                case "grpc":
                    Console.WriteLine("--- gRPC CALL STARTED ---");
                    AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                    await Run(new GrpcFizzService(), new GrpcBuzzService(), new GrpcNumberService());
                    Console.WriteLine("--- gRPC CALL ENDED ---");
                    break;
                default:
                    Console.WriteLine("--- MONOLITH RUN STARTED ---");
                    await Run(new InternalFizzService(), new InternalBuzzService(), new InternalNumberService());
                    Console.WriteLine("--- MONOLITH RUN ENDED ---");
                    break;
            }
        }

        private static async Task Run(IFizzService fizzService, IBuzzService buzzService, INumberService numberService)
        {
            var max = 120;

            var timings = new Timings();

            var numbers = numberService.GetAll(max);
            await foreach (var number in numbers)
            {
                var fizz = await fizzService.Get(number.Id);
                var buzz = await buzzService.Get(number.Id);

                var word = fizz.Fizzable ? $"Fizz{buzz?.Word}" : buzz?.Word ?? number.Word;
                if (number.Id == 1)
                {
                    timings.FirstResult = DateTime.Now;
                }
                Console.WriteLine(word);
            }
            timings.End = DateTime.Now;
            timings.Print();
        }
    }
}
