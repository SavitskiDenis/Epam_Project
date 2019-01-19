using SpecialInsulator.Common.Loger;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonRegistry:Registry
    {
        public CommonRegistry()
        {
            For<ILogger>().Singleton().Use<Logger>();
        }
    }
}
