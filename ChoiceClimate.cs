using Plague_Inc._2._0.Classes;
using Plague_Inc._2._0.Classes.Climat;
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
    public partial class ChoiceClimate : Form
    {
        internal MainCS disease = new MainCS();
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
            this.DoubleBuffered = true;
            button1.BackgroundImage = ImageWork.CreateDimmedImage(button1.BackgroundImage);
            button2.BackgroundImage = ImageWork.CreateDimmedImage(button2.BackgroundImage);
            button3.BackgroundImage = ImageWork.CreateDimmedImage(button3.BackgroundImage);
            button4.BackgroundImage = ImageWork.CreateDimmedImage(button4.BackgroundImage);
            button5.BackgroundImage = ImageWork.CreateDimmedImage(button5.BackgroundImage);
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
                if (button.Equals(button2) && !button2.BackgroundImage.Equals(c1) && Helper())
                {
                    disease.Climate.cold1 = true;
                    button.BackgroundImage = c1;
                    button1.Visible = true;
                }
                else if (button.Equals(button1) && disease.Climate.cold1 && !button1.BackgroundImage.Equals(c2) && Helper())
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
        bool ShowHard()
        {

            if(button4.BackgroundImage.Equals(h2) && button1.BackgroundImage.Equals(c2) && !button5.Visible)
            {
                button5.Visible = true;
                return true;
            }
            return false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ChoiceDrugs choiceDrugs = new ChoiceDrugs(disease);
            choiceDrugs.Show();
            this.Hide();
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            lbl.BackColor = Color.Transparent;
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            TextRenderer.DrawText(g, lbl.Text, lbl.Font, lbl.ClientRectangle, lbl.ForeColor, Color.Transparent, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            lbl.BringToFront();
        }

    }
}
