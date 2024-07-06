using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using load__baze.Models;

namespace load__baze.Models
{
    public class Country
    {
        public string name { get; set; }
        public decimal coefficient { get; set; }
        public decimal discount { get; set; }
        public List<Manufacturer> countryManufacturers { get; set; }
    }
}
