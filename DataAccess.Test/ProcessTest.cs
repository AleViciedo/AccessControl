using AccessControl.Contracts;
using AccessControl.DataAccess.Context;
using AccessControl.DataAccess.Repositories.Entities;
using AccessControl.DataAccess.Test.Utilities;
using AccessControl.DataAccess;
using Contracts.Entities;

namespace DataAccess.Test
{
    [TestClass]
    public class ProcessTest
    {
        private IPersonRepository _personRepository;
        private IUnitOfWork _unitOfWork;

        public ProcessTest()
        {
            ApplicationContext context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _personRepository = new PersonRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}