using AccessControl.DataAccess.Context;
using AccessControl.DataAccess.Repositories.Common;
using AccessControl.Domain.Entities.ConfigurationData;
using Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Domain;

namespace AccessControl.DataAccess.Repositories.Entities
{
    public class PersonRepository :RepositoryBase, IPersonRepository
    {
        public PersonRepository(ApplicationContext context) : base(context) { }
        public void AddPerson(Person person)
        {
            _context.Persons.Add(person);
        }

        public T? GetPersonById<T>(Guid id) where T : Person
        {
            return (T?)_context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<T> GetAllPersons<T>() where T : Person
        {
            return (IEnumerable<T>)_context.Persons.ToList();
        }

        public void UpdatePerson(Person person)
        {
            _context.Persons.Update(person);
        }

        public void DeletePerson(Person person)
        {
            _context.Persons.Remove(person);
        }
    }
}
