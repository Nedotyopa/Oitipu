using System;

namespace ToplivoCodeFirst.Models
{
    //Класс для организации разбиения на страницы
    public class PageInfo
    {
        public int PageNumber { get; set; }//номер страницы
        public int PageSize { get; set; }//количество объектов на странице
        public int TotalItems { get; set; }//Общее количество лбъектов
        public int TotalPages {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); } }//Общее количество страниц

    }
}