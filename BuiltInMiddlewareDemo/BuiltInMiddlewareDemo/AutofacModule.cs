using Autofac;
using BuiltInMiddlewareDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltInMiddlewareDemo
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlDataManager>().As<IDataManager>().InstancePerDependency();
         }
    }
}
