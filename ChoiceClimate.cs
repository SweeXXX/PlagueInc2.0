using Plague_Inc._2._0.Classes;
using Plague_Inc._2._0.Classes.Climat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plague_Inc._2._0
{
    public partial class ChoiceClimate : Form
    {
        internal MainCS disease = new MainCS();
        private Dictionary<Button, string> buttonStringMap;
        Image c1 = global::Plague_Inc._2._0.Properties.Resources._2023_05_17_20_15_30,
            c2 = global::Plague_Inc._2._0.Properties.Resources._2023_05_17_20_16_43,
            h1 = global::Plague_Inc._2._0.Properties.Resources._2023_05_17_20_17_22,
            h2 = global::Plague_Inc._2._0.Properties.Resources._2023_05_17_20_18_03,
            har = global::Plague_Inc._2._0.Properties.Resources._2023_05_17_20_18_48;
        public ChoiceClimate()
        {
            InitializeComponent();
        }
        internal ChoiceClimate(MainCS disease)
        {
            this.disease = disease;
            InitializeComponent();
            
        }

        private void DefPaint(object sender, PaintEventArgs e)
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
        private void ChoiceClimate_Load(object sender, EventArgs e)
        {
            label2.Text = disease.Score.ToString();
            disease.Temp = disease.Score;
            InitializeButtonMap();
            this.DoubleBuffered = true;
            button1.BackgroundImage = ImageWork.CreateDimmedImage(button1.BackgroundImage);
            button2.BackgroundImage = ImageWork.CreateDimmedImage(button2.BackgroundImage);
            button3.BackgroundImage = ImageWork.CreateDimmedImage(button3.BackgroundImage);
            button4.BackgroundImage = ImageWork.CreateDimmedImage(button4.BackgroundImage);
            button5.BackgroundImage = ImageWork.CreateDimmedImage(button5.BackgroundImage);
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string type = buttonStringMap[clickedButton];
            label3.Text = type;
        }
        bool Helper()
        {
            DialogResult mb = MessageBox.Show("Хотите приобрести этот навык?",
                "Хотите приобрести этот навык?",
                MessageBoxButtons.YesNo);
            return mb == DialogResult.Yes;
        }
        private void UppDate_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (disease.Score - 10 >= 0)
            {
                bool flag = true;
                Button button = (Button)sender;
                if (button.Equals(button1) && !button1.BackgroundImage.Equals(c1) && Helper())
                {
                    disease.Climate.cold1 = true;
                    button.BackgroundImage = c1;
                    button2.Visible = true;
                }
                else if (button.Equals(button2) && disease.Climate.cold1 && !button2.BackgroundImage.Equals(c2) && Helper())
                {
                    disease.Climate.cold2 = true;
                    button.BackgroundImage = c2;
                    ShowHard();
                }

                else if (button.Equals(button3) && !button3.BackgroundImage.Equals(h1) && Helper())
                {
                    disease.Climate.hot1 = true;
                    button.BackgroundImage = h1;
                    button4.Visible = true;

                }

                else if (button.Equals(button4) && disease.Climate.hot1 && !button4.BackgroundImage.Equals(h2) && Helper())
                {
                    disease.Climate.hot2 = true;
                    button.BackgroundImage = h2;
                    ShowHard();
                }

                else if (button.Equals(button5) && disease.Climate.hot2 && disease.Climate.cold2 && !button5.BackgroundImage.Equals(har) && Helper())
                {
                    disease.Climate.hardening = true;
                    button.BackgroundImage = har;
                    disease.Score -= 20;
                }
                else
                {
                    flag = false;
                }
                if (flag)
                {
                    disease.Score -= 10;
                    lblScoreUpdate();
                }
            }
            else if (disease.Score - 10 < 0)
            {
                MessageBox.Show("У вас недостаточно очков, для прокачки навыка обходимо минимум 10 очков");
            }
        }
        bool OpenButton(Button button, int num)
        {
            if (disease.Score - num >= 0 && !button.Visible)
            {
                disease.Score -= num;
                button.Visible = true;
                return true;
            }
            return false;
        }
        void lblScoreUpdate()
        {
            label2.Text = disease.Score.ToString();
        }

        private void RoundButton(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;

            GraphicsPath path = new GraphicsPath();
            int diameter = Math.Min(button.Width, button.Height) -7;

            path.AddEllipse(
                (button.Width - diameter) / 2,
                (button.Height - diameter) / 2,
                diameter,
                diameter);

            button.Region = new Region(path);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            disease.Score = disease.Temp;
            ChoiceType choiceType = new ChoiceType(disease);
            choiceType.Show();
            this.Hide();
        }

        private void ChoiceClimate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        bool ShowHard()
        {

            if(button4.BackgroundImage.Equals(h2) && button2.BackgroundImage.Equals(c2) && !button5.Visible)
            {
                button5.Visible = true;
                return true;
            }
            return false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            disease.Temp = disease.Score;
            this.Hide();
            var form2 = new ChoiceDrugs(disease);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
        private void InitializeButtonMap()
        {
            buttonStringMap = new Dictionary<Button, string>
        {
            { button2, "Патоген выживает в условиях низких температур и в холодном климате."},
            { button1, "Малый объем внутриклеточной воды препятствует замерзанию. Повышается эффективность болезни в странах с холодным климатом." },
            { button3, "Патоген выживает в условиях высоких температур и в жарком климате."},
            { button4, "Патоген выживает при высоких температурах. Повышается эффективность в жарких странах."},
            { button5, "Укрепление оболочки патогена делает его невосприимчивым к атмосферным воздействиям в жарком и холодном климате."}
        };
        }
        private void label1_Paint(object sender, PaintEventArgs e)
        {
            System.Windows.Forms.Label lbl = sender as System.Windows.Forms.Label;
            lbl.BackColor = Color.Transparent;
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            TextRenderer.DrawText(g, lbl.Text, lbl.Font, lbl.ClientRectangle, lbl.ForeColor, Color.Transparent, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            lbl.BringToFront();
        }

    }
}
