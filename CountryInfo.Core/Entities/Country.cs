using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfo.Core.Entities
{
    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
        public List<string> Currencies { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Borders { get; set; }
    }
}
