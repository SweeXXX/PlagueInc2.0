using Plague_Inc._2._0.Classes;
using Plague_Inc._2._0.Classes.TypesCS;
using Plague_Inc._2._0.Interfaceses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plague_Inc._2._0
{
    public partial class ChoiceType : Form
    {
        MainCS disease = new MainCS();
        private MusicPlayer musicPlayer;
        private Dictionary<Button, ITypeable> buttonStringMap;
        public ChoiceType()
        {
            musicPlayer = new MusicPlayer();
            InitializeComponent();
        }
        internal ChoiceType(MainCS mainCS)
        {
            musicPlayer = new MusicPlayer();
            disease = mainCS;
            InitializeComponent();
        }
        private void Def_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            GraphicsPath path = new GraphicsPath();

            int width = button.Width - 1;
            int height = button.Height - 1;

            int halfWidth = width / 2;
            int halfHeight = height / 2;

            // Define the points of the hexagon
            Point[] points = new Point[]
            {
        new Point(halfWidth / 2, 0),
        new Point(width - halfWidth / 2, 0),
        new Point(width, halfHeight),
        new Point(width - halfWidth / 2, height),
        new Point(halfWidth / 2, height),
        new Point(0, halfHeight)
            };

            path.AddPolygon(points);
            button.Region = new Region(path);
            try
            {
                // Draw the image
                e.Graphics.DrawImage(button.BackgroundImage, new Rectangle(0, 0, button.Width, button.Height));
            }
            catch 
            {
                
            }

        }


        void Tr()
        {
            var mb = MessageBox.Show("Вы хотите выбрать этот патоген?", "Выбор патоГена", MessageBoxButtons.YesNo);
            if (mb == DialogResult.Yes)
            {
                ChoiceClimate choiceClimate = new ChoiceClimate(disease);
                choiceClimate.Show();
                this.Hide();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

            button1.Visible = true;
        }

        private void ChoiceType_Load(object sender, EventArgs e)
        {
            musicPlayer.Start();
            InitializeButtonMap();
        }
        private void InitializeButtonMap()
        {
            buttonStringMap = new Dictionary<Button, ITypeable>
        {
            { button1, new Bacterium()},
            { button2, new BioWeapon() },
            { button3, new NanoVirus()},
            { button4, new NanoVirus()},
            { button5, new Prion()},
            { button6, new Glist()},
            { button7, new Virus() }
        };
        }
        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            var type = buttonStringMap[clickedButton];
            label1.Text = type.ToString();  
            if(e.Button == MouseButtons.Left) 
            {
                disease.typeOfDisease = type;
                Tr();
            }
        }
        private void RoundButton(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;

            GraphicsPath path = new GraphicsPath();
            int diameter = Math.Min(button.Width, button.Height) - 7;

            path.AddEllipse(
                (button.Width - diameter) / 2,
                (button.Height - diameter) / 2,
                diameter,
                diameter);

            button.Region = new Region(path);
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            var type = buttonStringMap[clickedButton];
            label1.Text = type.ToString();
        }

        private void ChoiceType_FormClosing(object sender, FormClosingEventArgs e)
        {
            musicPlayer.Stop();
            Application.Exit();
        }
    }
}
