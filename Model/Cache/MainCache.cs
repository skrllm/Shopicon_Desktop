using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopicon.Model
{

    class MainCache
    {
        static bool IsAccountEnter = false;
        static string[] AccountData = new string[2]; // [0] = ID_Account,[1] = Name

        public bool FunctionIsAccountEnter()
        {
            return IsAccountEnter;
        }
        public void FunctionIsAccountEnter(bool IsAccountEnterFromMethod)
        {
            IsAccountEnter = IsAccountEnterFromMethod;
            if (IsAccountEnterFromMethod == false) { Clean(); }
        }
        public void AccountEntered(string ID_Account,string Name)
        {
            AccountData[0] = ID_Account;
            AccountData[1] = Name;
        }
        public string[] Information()
        {
            return AccountData;
        }
        void Clean()
        {
            for (int i = 0; i < 2; AccountData[i++] = "") { }

        }

    }
}
