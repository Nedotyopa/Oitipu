using System.Collections.Generic;
using ToplivoCodeFirst.Models;


namespace ToplivoCodeFirst.PL
{
    public class PagedCollection<T>
    {
        public IEnumerable<T> PagedItems { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}