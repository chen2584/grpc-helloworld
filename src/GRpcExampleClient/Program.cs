using System;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using System.Threading.Tasks;

namespace GRpcExampleClient
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            var channel = new Channel("localhost:2584", ChannelCredentials.Insecure);

            var client = new UserService.UserServiceClient(channel);

            var data = new RequestUser
            {
                //Name = "Worameth Semapat",
                Email = "worameth.semapat@gmail.com",
                BirthDay = Timestamp.FromDateTime(new DateTime(1992, 07, 04, 0, 0, 0, DateTimeKind.Utc))
            };
            var response = await client.GetUserDetailAsync(data);

            Console.WriteLine($"Message: {response.Message}, Current Age: {response.Age}");
            channel.ShutdownAsync().Wait();
        }
    }
}
