using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ToplivoCodeFirst.Models;

namespace ToplivoCodeFirst.Models
{
    public class ToplivoDbInitializer : DropCreateDatabaseAlways<ToplivoContext>
    {
        protected override void Seed(ToplivoContext db)
        {
            db.Tanks.Add(new Tank { TankID = 1, TankType = "Цистерна", TankWeight = 1863, TankVolume = 123, TankMaterial = "Сталь" });
            db.Fuels.Add(new Fuel { FuelID = 1, FuelType = "Нефть", FuelDensity = 1863});

            db.SaveChanges();
        }
    }
}