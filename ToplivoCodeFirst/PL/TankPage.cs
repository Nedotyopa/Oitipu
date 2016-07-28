using System.Collections.Generic;
using ToplivoCodeFirst.Models;

namespace ToplivoCodeFirst.PL
{
    public class TankPage
    {
        public IEnumerable<Tank> Tanks { get; set;}
        public PageInfo PageInfo {get;set;}
    }
}