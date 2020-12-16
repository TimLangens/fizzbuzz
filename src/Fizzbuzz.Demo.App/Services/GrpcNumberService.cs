using Fizzbuzz.Demo.App.Models;
using FizzBuzz.Demo.App;
using Grpc.Core;
using Grpc.Net.Client;
using System.Collections.Generic;

namespace Fizzbuzz.Demo.App.Services
{
    public class GrpcNumberService : INumberService
    {
        private readonly string _channelUrl;

        public GrpcNumberService()
        {
            _channelUrl = "http://grpc.numbers.localhost:80";
        }

        public async IAsyncEnumerable<NumberModel> GetAll(int max = 1000)
        {
            using var numberschannel = GrpcChannel.ForAddress(_channelUrl);
            var numbersClient = new Number.NumberClient(numberschannel);

            var request = new NumbersRequest { Max = max };

            using var numberStream = numbersClient.GetNumbers(request);
            await foreach (var number in numberStream.ResponseStream.ReadAllAsync())
            {
                yield return new NumberModel
                {
                    Id = number.Id,
                    Binary = number.Binary,
                    Word = number.Word
                };
            }
        }
    }
}