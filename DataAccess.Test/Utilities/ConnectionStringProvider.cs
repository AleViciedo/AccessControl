using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.DataAccess.Test.Utilities
{
    static public class ConnectionStringProvider
    {
        public static string GetConnectionString() => "Data Source=Data.sqlite";
    }
}
