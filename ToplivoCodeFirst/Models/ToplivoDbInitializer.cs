using System;
using System.Data.Entity;

namespace ToplivoCodeFirst.Models
{
    public class ToplivoDbInitializer : DropCreateDatabaseAlways<ToplivoContext>
    {
        protected override void Seed(ToplivoContext db)
        {
            //Заполнение таблицы емкостей
            for (int tankID=1; tankID < 101; tankID++)
            {
                string tankType = "Емкость_" + tankID.ToString();
                string tankMaterial = "Материал_" + tankID.ToString();
                Random randObj = new Random(tankID);
                float tankWeight = 500*(float)randObj.NextDouble();
                float tankVolume = 200 * (float)randObj.NextDouble();
                db.Tanks.Add(new Tank { TankID = tankID, TankType = tankType, TankWeight = tankWeight, TankVolume = tankVolume, TankMaterial = tankMaterial });
            }
            //Заполнение таблицы видов топлива
            for (int fuelID = 1; fuelID < 101; fuelID++)
            {
                string fuelType = "Топливо_" + fuelID.ToString();
                Random randObj = new Random(fuelID);
                float fuelDensity = 2 * (float)randObj.NextDouble();
                db.Fuels.Add(new Fuel { FuelID = fuelID, FuelType = fuelType, FuelDensity = fuelDensity });
            }

            db.SaveChanges();
        }
        
    }
}