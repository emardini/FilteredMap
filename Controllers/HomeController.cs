
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using filteredMap.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace filteredMap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("https://maps.googleapis.com/maps/api/place/textsearch/json?query=parks+in+Virginia+Beach+,+VA&key=AIzaSyAtbBkcrGo97HSiQRD3seMq3NxwD6K5RWA");

            var placeSearchResult = JsonConvert.DeserializeObject<PlaceSearchResult>(result) ?? new PlaceSearchResult { Results = new List<GPlace> { } };

            var places = placeSearchResult.Results.Select(x => new Place { Address = x.Formatted_Address, Location = new Location { Latitude = x.Geometry.Location.Lat, Longitude = x.Geometry.Location.Lng }, Name = x.Name });

            return View(places);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


public class GLocation
{
    public double Lat { get; set; }
    public double Lng { get; set; }
}

public class Geometry
{
    public GLocation Location { get; set; }
}

public class GPlace
{
    public Geometry Geometry { get; set; }
    public string Formatted_Address { get; set; }

    public string Name { get; set; }
}

public class PlaceSearchResult
{
    public IEnumerable<GPlace> Results { get; set; }
}


public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class Place
{
    public string Address { get; set; }

    public string Name { get; set; }

    public Location Location { get; set; }
}
