using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace магазин_авто.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<BuyCar> BuyCars { get; set; }
        public Buyer()
        {
            BuyCars = new List<BuyCar>();
        }
    }
}