namespace ToplivoCodeFirst.Models
{
    //Класс для хранения данных сеанса
    public struct TransferData
    {
        public int TankPage; // номер текущей страницы для работы с табличными данными в Tanks
        public int FuelPage; // номер текущей страницы для работы с табличными данными в Fuels
        public int OperationPage; // номер текущей страницы для работы с табличными данными в Operations
        public string strTankTypeFind; // строка поиска по названиям в Tanks
        public string strFuelTypeFind; // строка поиска по названиям в Fuels

        public TransferData(int tankpage=1, int fuelpage=1, int operationkpage = 1, string strtanktypefind="", string strfueltypefind = "")
        {
            TankPage = tankpage;
            FuelPage = fuelpage;
            OperationPage = operationkpage;
            strTankTypeFind = strtanktypefind;
            strFuelTypeFind = strfueltypefind;
        }
        
    }
}