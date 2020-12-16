using Grpc.Core;
using System.Threading.Tasks;

namespace FizzBuzz.Grpc.Buzz
{
    public class BuzzService : Buzz.BuzzBase
    {
        public override async Task<BuzzReply> Buzzify(BuzzId request, ServerCallContext context)
        {
            await Task.Delay(50);
            return new BuzzReply
            {
                Word = request.Id % 5 == 0 ? "Buzz" : string.Empty
            };
        }
    }
}
