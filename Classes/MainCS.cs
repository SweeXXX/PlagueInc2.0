using Plague_Inc._2._0.Interfaceses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plague_Inc._2._0.Classes.Climat;
using Plague_Inc._2._0.Classes.DrugsChoice;

namespace Plague_Inc._2._0.Classes
{
    internal class MainCS
    {
        int score = 100;
        internal ITypeable typeOfDisease;
        public Climate Climate = new Climate();
        internal Drugs Drug = new Drugs();
        internal int Score
        {
            get { return score; }
            set 
            { 
                if(value>= 0)
                    score = value; 
            }
        }
    }
}
