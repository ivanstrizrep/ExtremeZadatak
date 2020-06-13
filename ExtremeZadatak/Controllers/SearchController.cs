using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExtremeZadatak.Hubs;
using ExtremeZadatak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace ExtremeZadatak.Controllers
{
    public class SearchController : ControllerBase
    {
        private readonly LocationSearchDBContext locationSearchDBContext = new LocationSearchDBContext();
        private readonly IHubContext<MessageHub> _hubContext;

        public SearchController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("Search/GetPlaces")]
        public async Task<string> GetPlaces(float latitude, float longitude, int radius, string category)
        {
            var locationSearch = new LocationSearch
            {
                Latitude = latitude,
                Longitude = longitude,
                Radius = radius,
                Category = category,
                Time = DateTime.Now
            };
            locationSearchDBContext.LocationSearch.Add(locationSearch);
            locationSearchDBContext.SaveChanges();

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", latitude, longitude, radius, category);

            using (HttpClient client = new HttpClient())
            {
                var key = "";

                var response = await client.GetStringAsync(string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius={2}&type={3}&key={4}", latitude, longitude, radius, category, key));
                return response;
            }
        }

        [HttpGet]
        [Route("Search/GetSearches")]
        public IEnumerable<LocationSearch> GetSearches()
        {
            return locationSearchDBContext.LocationSearch.ToList();
        }
    }
}
