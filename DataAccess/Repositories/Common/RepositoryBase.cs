using AccessControl.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.DataAccess.Repositories.Common
{
    abstract public class RepositoryBase
    {
        protected ApplicationContext _context;

        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
    }
}
