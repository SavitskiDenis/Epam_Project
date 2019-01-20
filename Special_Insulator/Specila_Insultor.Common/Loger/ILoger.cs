using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialInsulator.Common.Loger
{
    public interface ILogger
    {
        void Error(string message);
    }
}
