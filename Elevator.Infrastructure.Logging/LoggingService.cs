using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elevator.Infrastructure.Interfaces;
using log4net;
using log4net.Core;

namespace Elevator.Infrastructure.Logging
{
    public class LoggingService : ILoggingService
    {
        private ILog _log;

        public LoggingService(ILog log)
        {
            log4net.Config.XmlConfigurator.Configure();

            _log = log;

            
        }

        public void Debug(string message)
        {
            if (!_log.IsDebugEnabled) return;
            _log.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            if (!_log.IsDebugEnabled) return;
            _log.Debug(message, exception);
        }

        public void Error(string message)
        {
            if (!_log.IsErrorEnabled) return;
            _log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            if (!_log.IsErrorEnabled) return;
            _log.Error(message, exception);
        }

        public void Fatal(string message)
        {
            if (!_log.IsFatalEnabled) return;
            _log.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            if (!_log.IsFatalEnabled) return;
            _log.Fatal(message, exception);
        }

        public void Info(string message)
        {
            if (!_log.IsInfoEnabled) return;
            _log.Info(message);
        }

        public void Info(string message, Exception exception)
        {
            if (!_log.IsInfoEnabled) return;
            _log.Info(message, exception);
        }

        public void Warn(string message)
        {
            if (!_log.IsWarnEnabled) return;
            _log.Warn(message);
        }

        public void Warn(string message, Exception exception)
        {
            if (!_log.IsWarnEnabled) return;
            _log.Warn(message, exception);
        }
    }
}
