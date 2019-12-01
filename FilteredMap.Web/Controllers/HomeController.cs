
using FilteredMap.Core;
using FilteredMap.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FilteredMap.Web.Controllers
{
    public class HomeController : Controller
    {
        //Depend on abstractions, not implementations
        private readonly ILogger<HomeController> logger;
        private readonly IPlaceSearch placeSearch;

        public HomeController(ILogger<HomeController> logger, IPlaceSearch placeSearch)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.placeSearch = placeSearch ?? throw new ArgumentNullException(nameof(placeSearch));
        }

        public async Task<IActionResult> Index()
        {
            var places = await placeSearch.GetPlaces();
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