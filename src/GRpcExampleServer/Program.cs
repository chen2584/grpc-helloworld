using System;
using Grpc.Core;

namespace GRpcExampleServer
{
    public class UserService : 
    {

    }

    class Program
    {
        public 
        static void Main(string[] args)
        {
            var server = new Server
            {
                Services = Services,
                Ports = { new ServerPort("0.0.0.0", "2584", ServerCredentials.Insecure); }
            };
        }
    }
}
