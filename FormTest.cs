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
    public partial class FormTest : Form
    {
        MainCS disease = new MainCS();
        public FormTest()
        {
            InitializeComponent();
        }
        internal FormTest(MainCS mainCS)
        {
            disease = mainCS;
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            label2.Text = disease.Score.ToString();
            pictureBox2.Image = disease.image; 
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new ChoiceType();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
