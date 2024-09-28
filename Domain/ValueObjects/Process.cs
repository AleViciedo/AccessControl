using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Process
    {
        public string Name { get; set; }
        List<string> Products { get; set; }

        public Process()
        {
            Name = string.Empty;
            Products = new List<string>();
        }

        public Process(string name, List<string> products)
        {
            Name = name;
            Products = products;
        }
    }
}
