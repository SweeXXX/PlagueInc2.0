using Plague_Inc._2._0.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plague_Inc._2._0
{
    public partial class LastForm : Form
    {
        MainCS disease = new MainCS();
        public LastForm()
        {
            InitializeComponent();
        }
        internal LastForm(MainCS disease)
        {
            this.disease = disease;
        }
    }
}
