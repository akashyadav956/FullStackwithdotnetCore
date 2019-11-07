using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltInMiddlewareDemo.Repository
{
   public interface IDataManager
    {
        string GetData();
        string GetGreeting();
    }
}
