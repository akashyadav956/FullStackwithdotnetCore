using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltInMiddlewareDemo.Repository
{
    public class NoSqlDataManager : IDataManager
    {
        public string GetData()
        {
            return "NoSqlDataMange - Hello World";
        }

        public string GetGreeting()
        {
            return "NoSqlDataMange - GetGreeting";
        }
    }
}
