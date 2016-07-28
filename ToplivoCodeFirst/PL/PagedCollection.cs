using System.Collections.Generic;


namespace ToplivoCodeFirst.Models
{
    public class PagedCollection<T>
    {
        public IEnumerable<T> PagedItems { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}