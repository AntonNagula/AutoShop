using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace магазин_авто.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}