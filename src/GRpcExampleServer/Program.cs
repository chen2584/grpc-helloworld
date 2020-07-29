using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace GRpcExampleServer
{
    public class UserService : global::UserService.UserServiceBase
    {
        public override Task<ResponseUser> GetUserDetail(RequestUser request, ServerCallContext context)
        {
            var zeroTime = new DateTime(1, 1, 1);
            var span = DateTime.Now - request.BirthDay.ToDateTime();
            var age = (zeroTime + span).Year - 1;

            var response = new ResponseUser
            {
                Message = $"Hello {request.Name}, Your Email is {request.Email}.",
                Age = age
            };
            return Task.FromResult(response);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var port = 2584;

            var server = new Server
            {
                Services = { global::UserService.BindService(new UserService()) },
                Ports = { new ServerPort("0.0.0.0", port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
