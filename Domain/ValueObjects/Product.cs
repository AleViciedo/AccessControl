using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.ValueObjects
{
    [NotMapped]
    public class Product
    {
        public string Name { get; set; }

        //public Product(string name)
        //{
        //    Name = name;
        //}
        public Guid ProductId { get; set; }
        public ICollection<Process> Processes { get; set; } = new List<Process>();

        public Product(string name, Guid productId)
        {
            Name = name;
            ProductId = productId;
        }


    }
}
