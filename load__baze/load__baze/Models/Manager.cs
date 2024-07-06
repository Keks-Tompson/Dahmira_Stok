using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace load__baze.Models
{
    internal class Manager
    {
        private static Manager instance;

        public List<Manufacturer> allManufacturers { get; set; }
        public List<Country> countries { get; set; }

        private Manager()
        {
            allManufacturers = new List<Manufacturer> { };
            countries = new List<Country> { };
        }

        public static Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Manager();
                }
                return instance;
            }
        }
    }
}
