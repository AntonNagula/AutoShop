using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace магазин_авто.Models
{
    public class BoughtCar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CarBrand { get; set; }
        public double Price { get; set; }
    }
}