using AccessControl.Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Entities
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);

        T? GetPersonById<T>(Guid id) where T : Person;

        IEnumerable<T> GetAllPersons<T>() where T : Person;

        void UpdatePerson(Person person);

        void DeletePerson(Person person);
    }
}
