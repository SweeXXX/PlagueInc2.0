using Plague_Inc._2._0.Interfaceses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plague_Inc._2._0.Classes.TypesCS
{
    internal class Virus : ITypeable
    {
        void ITypeable.DoSomething() { }
        void ITypeable.GoNext() { }
        string ITypeable.ToString() 
        {
            return "Вирус нурминский";
        }
    }
}
