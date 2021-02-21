using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;


namespace Mines_Web.Services.Utility
{
    public class MinesAppLogger : ILogger
    {

        private Logger logger;

        private Logger GetLogger(string loggerName)
        {
            if (logger == null)
            {
                logger = LogManager.GetLogger(loggerName);
            }
            return logger;
        }
        public void Debug(string message)
        {
            GetLogger("myAppLoggerRules").Debug(message);
        }

        public void Error(string message)
        {
            GetLogger("myAppLoggerRules").Error(message);
        }

        public void Info(string message)
        {
            GetLogger("myAppLoggerRules").Info(message);
        }

        public void Warning(string message)
        {
            GetLogger("myAppLoggerRules").Warn(message);
        }
    }
}