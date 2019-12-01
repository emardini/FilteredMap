

using FilteredMap.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilteredMap.Infrastructure
{
    public class GooglePlaceSearch : IPlaceSearch
    {
        private readonly string apiKey;
        public GooglePlaceSearch(string apiKey)
        {
            this.apiKey = !string.IsNullOrWhiteSpace(apiKey) ? apiKey : throw new ArgumentNullException(nameof(apiKey));
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync($"https://maps.googleapis.com/maps/api/place/textsearch/json?query=parks+in+Virginia+Beach+,+VA&key={apiKey}");

            var placeSearchResult = JsonConvert.DeserializeObject<PlaceSearchResult>(result) ?? new PlaceSearchResult { Results = new List<GPlace> { } };

            var places = placeSearchResult.Results.Select(x => new Place { Address = x.Formatted_Address, Location = new Location { Latitude = x.Geometry.Location.Lat, Longitude = x.Geometry.Location.Lng }, Name = x.Name });

            return places;
        }
    }
}
