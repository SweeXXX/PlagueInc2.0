using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plague_Inc._2._0.Classes.Climat
{
    internal class Climate
    {

        internal bool cold1, cold2, hot1, hot2, hardening = false;
        internal Climate(bool cold1, bool cold2, bool hot1, bool hot2, bool hardening)
        {
            this.cold1 = cold1;
            this.cold2 = cold2;
            this.hot1 = hot1;
            this.hot2 = hot2;
            this.hardening = hardening;
        }
        internal Climate()
        {

        }
        internal void OpenHardenning()
        {
            hardening = true;
        }
        internal void OpenCold2()
        {
            cold2 = true;
        }
        internal void OpenHot2()
        {
            hot2 = true;
        }
        internal void OpenCold1()
        {
            cold1 = true;
        }
        internal void OpenHot1()
        {
            hot1 = true;
        }
        internal void Reset()
        {
            cold1 = false;
            hot2 = false;
            hot1 = false;
            hot2 = false;
            hardening = false;
        }
    }
}
