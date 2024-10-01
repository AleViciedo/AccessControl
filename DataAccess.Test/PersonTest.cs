using AccessControl.Contracts;
using AccessControl.DataAccess;
using AccessControl.DataAccess.Context;
using AccessControl.DataAccess.Repositories.Entities;
using AccessControl.DataAccess.Test.Utilities;
using AccessControl.Domain.Common;
using AccessControl.Domain.Entities.ConfigurationData;
using Contracts.Entities;

namespace DataAccess.Test
{
    [TestClass]
    public class PersonTest
    {
        private IPersonRepository _personRepository;
        private IUnitOfWork _unitOfWork;

        public PersonTest()
        {
            ApplicationContext context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _personRepository = new PersonRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow(null, "Chaviano", "44335516879", School.TechnicSchool)]
        [TestMethod]
        public void CanAddOperator(Supervisor? supervisor, string name, string cI, School school)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Operator @operator = new Operator(supervisor, name, cI, school, id);

            //Execute
            _personRepository.AddPerson(@operator);
            _unitOfWork.SaveChanges();

            //Assert
            Operator createdOperator = _personRepository.GetPersonById<Operator>(id);
            Assert.IsNotNull(createdOperator);
        }
    }
}