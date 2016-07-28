using System.Collections.Generic;
using ToplivoCodeFirst.Models;


namespace ToplivoCodeFirst.PL
{
    public class FuelPage
    {
        public IEnumerable<Fuel> Fuels { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}