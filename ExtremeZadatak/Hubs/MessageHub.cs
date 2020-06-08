using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtremeZadatak.Hubs
{
    public class MessageHub : Hub
    {
        /*public async Task SendMessage(float latitude, float longitude, int radius, string category)
        {
            await Clients.All.SendAsync("ReceiveMessage", latitude, longitude, radius, category);
        }*/
    }
}
