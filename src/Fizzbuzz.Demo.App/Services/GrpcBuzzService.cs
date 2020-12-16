using Fizzbuzz.Demo.App.Models;
using FizzBuzz.Demo.App;
using Grpc.Net.Client;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.Services
{
    public class GrpcBuzzService : IBuzzService
    {
        private readonly string _channelUrl;

        public GrpcBuzzService()
        {
            _channelUrl = "http://grpc.buzz.localhost:80";
        }

        public async Task<BuzzModel> Get(int id)
        {
            using var buzzChannel = GrpcChannel.ForAddress(_channelUrl);
            var buzzClient = new Buzz.BuzzClient(buzzChannel);

            var request = new BuzzId { Id = id };

            var reply = await buzzClient.BuzzifyAsync(request);

            return string.IsNullOrEmpty(reply.Word) ?
                null :
                new BuzzModel
                {
                    Id = id,
                    Word = reply.Word
                };
        }
    }
}