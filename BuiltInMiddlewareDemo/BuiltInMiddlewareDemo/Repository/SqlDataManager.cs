using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltInMiddlewareDemo.Repository
{
    public class SqlDataManager : IDataManager
    {
        public string GetData()
        {
            return "Hello World";
        }

        public string GetGreeting()
        {
            return "NoSqlDataMange - GetGreeting";
        }
    }
}
