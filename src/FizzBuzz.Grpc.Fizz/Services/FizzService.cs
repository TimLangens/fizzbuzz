using Grpc.Core;
using System.Threading.Tasks;

namespace FizzBuzz.Grpc.Fizz
{
    public class FizzService : Fizz.FizzBase
    {
        public override async Task<FizzReply> Fizzify(FizzId request, ServerCallContext context)
        {
            await Task.Delay(50);
            return new FizzReply
            {
                Fizzable = request.Id % 3 == 0
            };
        }
    }
}
