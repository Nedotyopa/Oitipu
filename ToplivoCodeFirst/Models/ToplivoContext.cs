using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToplivoCodeFirst.Models
{

    public class ToplivoContext : DbContext
    {
        public ToplivoContext() : base("ToplivoContext")
        {
        }
        public virtual DbSet<Fuel> Fuels { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Tank> Tanks { get; set; }
    }
}