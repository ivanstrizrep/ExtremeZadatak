using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SignalRConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder().WithUrl("https://localhost:44334/messageHub").Build();
            connection.StartAsync().Wait();
            connection.On("ReceiveMessage", (float latitude, float longitude, int radius, string category) =>
            {
                Console.WriteLine("SEARCH FOR - Latitude: " + latitude + ", Longitude: " + longitude + ", Radius: " + radius + ", Category: " + category);
            }
            );
            Console.ReadKey();
        }
    }
}
