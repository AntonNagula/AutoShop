using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace магазин_авто.Models
{
    public class Car
    {
        public Car(string Name, string CarBrand, int Count_Of_Unit, double Price)
        {
            this.Name = Name;
            this.Price=Price;
            this.CarBrand = CarBrand;
            this.Count_Of_Unit = Count_Of_Unit;
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExtencionName { get; set; }
        public string CarBrand { get; set; }
        public int Count_Of_Unit { get; set; }
        public double Price { get; set; }
        public byte[] image { get; set; }
        public string Info { get; set; }
        public virtual ICollection<BuyCar> BuyCars { get; set; }
        public Car()
        {
            BuyCars = new List<BuyCar>();
        }
    }
}