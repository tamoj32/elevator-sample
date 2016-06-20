using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elevator.Infrastructure.Interfaces;
using Elevator.Infrastructure.Logging;
using Ninject;
using Ninject.Modules;
using log4net;
using log4net.Repository.Hierarchy;

namespace Elevator.Infrastructure.DependencyResolution
{
    public class LoggingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(x =>
            {
                var name = x.Request.Target.Member.DeclaringType.FullName;
                return LogManager.GetLogger(name);
            });

            Bind<ILoggingService>().To<LoggingService>()
                .InSingletonScope();
        }
    }
}
