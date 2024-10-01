using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Domain;
using AccessControl.Domain.Common;
using AccessControl.Domain.Entities.ConfigurationData;

namespace AccessControl.Domain.ValueObjects
{
    public class Process : ValueObject
    {
        public Guid ProcessId { get; set; }  //Process es un ValueObject, pero debe ser tratado como Entity para la DB
        public string Name { get; set; }

        public List<Product> Products { get; set; }

        //public ProductSet ProductSet { get; set; }
        public ICollection<Operator> Operators { get; set; } = new List<Operator>();
        public ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();

        public Process()
        {
            Name = string.Empty;
            //ProductSet = new ProductSet();
            Products = new List<Product>();
        }

        public Process(Guid processId, string name, List<Product> products)
        {
            ProcessId = processId;
            Name = name;
            Products = products;
        }



        //public Process(string name, List<Product> products)
        //{
        //    Name = name;
        //    ProductSet = new ProductSet(Guid.NewGuid(), products, this);
        //}

        //public Process(string name, ProductSet productSet)
        //{
        //    Name = name;
        //    ProductSet = productSet;
        //}

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (Product product in Products)
            {
                yield return new object[] { product.Name };
            }
        }
    }
}
