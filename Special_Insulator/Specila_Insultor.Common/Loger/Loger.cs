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

        public  ILog For(object LoggerObject)
        {
            if(LoggerObject != null)
            {
                return For(LoggerObject.GetType());
            }
            else
            {
                return For(null);
            }
        }

        public  ILog For(Type ObjectType)
        {
            if (ObjectType != null)
            {
                return LogManager.GetLogger(ObjectType.Name);
            }
            else
            {
                return LogManager.GetLogger(string.Empty);
            }
        }

        public void Error(string message)
        {
            myLogger.Error(message);
        }

    }
}
