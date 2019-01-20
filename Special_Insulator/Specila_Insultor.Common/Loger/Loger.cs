using log4net;
using log4net.Config;
using System;

namespace SpecialInsulator.Common.Loger
{
    class Logger : ILogger
    {

        private readonly ILog myLogger;

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        public Logger()
        {
            InitLogger();
            myLogger = LogManager.GetLogger("MyLogger");
        }

        public void Error(string message)
        {
            myLogger.Error(message);
        }

    }
}
