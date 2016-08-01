using System;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace ToplivoCodeFirst.Models
{
    //Класс для инициализации базы данных путем заполнения ее таблиц тестовым набором записей
    public class ToplivoDbInitializer_runSQL : DropCreateDatabaseAlways<ToplivoContext>
    {
        protected override void Seed(ToplivoContext db)
        {
            string readPath = HttpContext.Current.Server.MapPath("~") + "/FillDB.sql";
            string SQLstring = "";
            try
            {
                //считывание текста SQL инструкции из внешнего текстового файла
                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    SQLstring = sr.ReadToEnd();
                }
                //Выполнение SQL инструкции
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