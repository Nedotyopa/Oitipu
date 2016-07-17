using System;
using System.Data.Entity;

namespace ToplivoCodeFirst.Models
{
    public class ToplivoDbInitializer2 : DropCreateDatabaseAlways<ToplivoContext>
    {
        protected override void Seed(ToplivoContext db)
        {
            string readPath = @"FillDB.sql";

            string SQLstring = "";
            try
            {
                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    SQLstring = sr.ReadToEnd();
                }
                

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}