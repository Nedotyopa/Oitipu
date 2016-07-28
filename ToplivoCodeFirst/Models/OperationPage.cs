using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToplivoCodeFirst.Models
{
    public class OperationPage
    {
        public IEnumerable<Operation> Operations { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}