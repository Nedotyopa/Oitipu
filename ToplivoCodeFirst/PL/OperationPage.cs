using System.Collections.Generic;
using ToplivoCodeFirst.Models;

namespace ToplivoCodeFirst.PL
{
    public class OperationPage
    {
        public IEnumerable<Operation> Operations { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}