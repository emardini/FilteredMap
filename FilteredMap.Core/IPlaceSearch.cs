using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilteredMap.Core
{
    public interface IPlaceSearch
    {
        Task<IEnumerable<Place>> GetPlaces();
    }
}
