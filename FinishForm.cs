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
    public partial class FinishForm : Form
    {
        MainCS disease = new MainCS();
        public FinishForm()
        {
            InitializeComponent();
        }
        internal FinishForm(MainCS mainCS)
        {
            disease = mainCS;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
