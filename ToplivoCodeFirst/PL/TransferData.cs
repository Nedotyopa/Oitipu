using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToplivoCodeFirst.Models
{
    //Класс для хранения данных сеанса
    public class TransferData
    {
        public int TankPage { get; set; } // номер текущей страницы для работы с табличными данными в Tanks
        public int FuelPage { get; set; } // номер текущей страницы для работы с табличными данными в Fuels
        public int OperationPage { get; set; } // номер текущей страницы для работы с табличными данными в Operations
        public string strTankTypeFind { get; set; } // строка поиска по названиям в Tanks
        public string strFuelTypeFind { get; set; } // строка поиска по названиям в Fuels

        public TransferData()
        {
            TankPage = 1;
            FuelPage = 1;
            OperationPage = 1;
            strTankTypeFind = "";
            strFuelTypeFind = "";
        }
        
    }
}