using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToplivoCodeFirst.Models
{
    public class Operation
    {
        //ID операции
        public int OperationID { get; set; }
        //ID топлива
        public int? FuelID { get; set; }
        //ID емкости
        public int? TankID { get; set; }
        //Приход/Расход
        public float? Inc_Exp { get; set; }
        //Дата операции
        public System.DateTime Date { get; set; }
        //ссылка на виды топлива
        public Fuel Fuel { get; set; }
        //ссылка на емкости
        public Tank Tank { get; set; }



    }
}