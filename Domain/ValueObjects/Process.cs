﻿using System;
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
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public ICollection<Person> Operators { get; set; } = new List<Person>();
        public ICollection<Person> Supervisors { get; set; } = new List<Person>();

        public Process()
        {
            Name = string.Empty;
        }

        public Process(string name, List<Product> products)
        {
            Name = name;
            Products = products;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (Product product in Products)
            {
                yield return new object[] { product.Name };
            }
        }
    }
}
