using System;
using System.Data.Entity;
using System.IO;

namespace ToplivoCodeFirst.Models
{
    public class ToplivoDbInitializer2 : DropCreateDatabaseAlways<ToplivoContext>
    {
        protected override void Seed(ToplivoContext db)
        {
            string readPath = @"C:\Users\olas\Source\Repos\ToplivoCodeFirst\ToplivoCodeFirst\FillDB.sql";

            string SQLstring = "";
            try
            {
                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    SQLstring = sr.ReadToEnd();
                }

                db.Database.ExecuteSqlCommand (SQLstring);

                base.Seed(db);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}