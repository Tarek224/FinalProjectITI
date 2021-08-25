using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Services
{
    public interface IFilterService<T>
    {
        List<T> FilterByCategory(int id);

        List<T> FilterByTags(int id);

        List<T> FilterByPrice(int price);

        List<T> SortingItems(int id);
    }
}
