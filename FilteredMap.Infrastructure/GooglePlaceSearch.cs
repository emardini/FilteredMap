

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
        private readonly HttpClient httpClient;

        private const string ApiUrl = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=parks+in+Virginia+Beach+,+VA&key={0}";

        public GooglePlaceSearch(string apiKey)
        {
            this.apiKey = !string.IsNullOrWhiteSpace(apiKey) ? apiKey : throw new ArgumentNullException(nameof(apiKey));
            this.httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            var result = await httpClient.GetStringAsync(string.Format(ApiUrl, apiKey));
            
            var placeSearchResult = JsonConvert.DeserializeObject<PlaceSearchResult>(result) ?? new PlaceSearchResult { Results = new List<GPlace> { } };

            var places = placeSearchResult.Results.Select(x => new Place { Address = x.Formatted_Address, Location = new Location { Latitude = x.Geometry.Location.Lat, Longitude = x.Geometry.Location.Lng }, Name = x.Name });

            return places;
        }
    }
}
