using log4net;
using System;

namespace SpecialInsulator.Common.Loger
{
    class Loger
    {
        public static ILog For(object LoggerObject)
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

        public static ILog For(Type ObjectType)
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
    }
}
