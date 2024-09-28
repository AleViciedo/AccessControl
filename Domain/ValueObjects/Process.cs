using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Domain;
using AccessControl.Domain.Common;

namespace AccessControl.Domain.ValueObjects
{
    public class Process : ValueObject
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (string str in Products)
            {
                yield return new object[] { str };
            }
        }
    }
}
