using Fizzbuzz.Demo.App.Models;
using FizzBuzz.Demo.App;
using Grpc.Net.Client;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.Services
{
    public class GrpcFizzService : IFizzService
    {
        private readonly string _channelUrl;

        public GrpcFizzService()
        {
            _channelUrl = "http://grpc.fizz.localhost:80";
        }

        public async Task<FizzModel> Get(int id)
        {
            using var fizzChannel = GrpcChannel.ForAddress(_channelUrl);
            var fizzClient = new Fizz.FizzClient(fizzChannel);

            var request = new FizzId { Id = id };

            var reply = await fizzClient.FizzifyAsync(request);

            return new FizzModel
            {
                Id = id,
                Fizzable = reply.Fizzable
            };
        }
    }
}