using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace магазин_авто.Models
{
    public class BuyCar
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }
    }
}