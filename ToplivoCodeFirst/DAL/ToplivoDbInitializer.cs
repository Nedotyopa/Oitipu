using System;
using System.Data.Entity;

namespace ToplivoCodeFirst.Models
{
    public class ToplivoDbInitializer : CreateDatabaseIfNotExists<ToplivoContext>
    {
        protected override void Seed(ToplivoContext db)
        {
            int tanks_number = 100;
            int fuels_number = 10;
            int operations_number = 10;

            //Заполнение таблицы емкостей
            string[] tank_voc = { "Цистерна_", "Ведро_", "Бак_", "Фляга_" };
            string[] material_voc = { "Сталь", "Дерево", "Алюминий", "Полиэтилен" };
            int count_tank_voc = tank_voc.GetLength(0);
            int count_material_voc = material_voc.GetLength(0);
            
            for (int tankID=1; tankID <= tanks_number; tankID++)
            {
                Random randObj = new Random(tankID);
                string tankType = tank_voc[randObj.Next(count_tank_voc)] + tankID.ToString();
                string tankMaterial = material_voc[randObj.Next(count_material_voc)];
                float tankWeight = 500*(float)randObj.NextDouble();
                float tankVolume = 200 * (float)randObj.NextDouble();
                db.Tanks.Add(new Tank { TankID = tankID, TankType = tankType, TankWeight = tankWeight, TankVolume = tankVolume, TankMaterial = tankMaterial });
            }

            //Заполнение таблицы видов топлива
            string[] fuel_voc = { "Нефть_", "Бензин_", "Керосин_", "Мазут_" };
            int count_fuel_voc = fuel_voc.GetLength(0);
            for (int fuelID = 1; fuelID <= fuels_number; fuelID++)
            {
                Random randObj = new Random(fuelID);
                string fuelType = fuel_voc[randObj.Next(count_fuel_voc)] + fuelID.ToString();
                float fuelDensity = 2 * (float)randObj.NextDouble();
                db.Fuels.Add(new Fuel { FuelID = fuelID, FuelType = fuelType, FuelDensity = fuelDensity });
            }

            //Заполнение таблицы 

            for (int operationID = 1; operationID <= operations_number; operationID++)
            {
                Random randObj = new Random(operationID);
                int tankID = randObj.Next(tanks_number);
                int fuelID= randObj.Next(fuels_number);
                DateTime today = DateTime.Now;
                DateTime operationdate = today.AddDays(-operationID);
                db.Operations.Add(new Operation { OperationID= operationID, TankID = tankID, FuelID = fuelID, Inc_Exp=10, Date= operationdate });
            }

            db.SaveChanges();
        }
        
    }
}