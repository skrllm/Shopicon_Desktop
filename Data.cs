using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopicon
{
    
    class Data
    {
        static bool IsAccountEnter = false;


        public bool FunctionIsAccountEnter()
        {
            return IsAccountEnter;
        }
        public void FunctionIsAccountEnter(bool IsAccountEnterFromMethod)
        {
            IsAccountEnter = IsAccountEnterFromMethod;
        }
    }
}
