using System.Collections.Generic;


namespace ToplivoCodeFirst.Models
{
    public class ViewModel<T>
    {
        public T Fields { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}