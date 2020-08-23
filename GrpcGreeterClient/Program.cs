using System;
using System.Net.Http;
using System.Threading.Tasks;
using GrpcGreeter;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001"); // Initiate a GrpcChannel containing the information for creating the connection to the gRPC service
            var client = new Greeter.GreeterClient(channel); // Using the GrpcChannel to construct the Greeter client
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" }); // call the asynchronous remote process, `HelloRequest`.
            Console.WriteLine("Greeting: " + reply.Message); 
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}