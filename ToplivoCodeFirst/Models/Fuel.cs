//Класс, отображаемый в таблицу Fuels базы данных
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToplivoCodeFirst.Models
    
{
    public class Fuel
    {
        //Id Топлива
        [Key]
        [Display(Name = "Код топлива")]
        public int FuelID { get; set; }

        //Наименование вида топлива
        [Display(Name = "Наименование топлива")]
        public string FuelType { get; set; }

        //Плотность вида топлива
        [Display(Name = "Плотность топлива")]
        public float FuelDensity { get; set; }
        
        //Коллекция объектов Operation, связанных с моделью
        public virtual ICollection<Operation> Operations { get; set; }
        
 
    }
}