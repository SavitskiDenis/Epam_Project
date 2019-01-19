using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialInsulator.Common.Checker
{
    public class Checker
    {
        public static bool CheckedForNull(params object[] myObjects)
        {
            foreach(var item in myObjects)
            {
                if(item == null)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
