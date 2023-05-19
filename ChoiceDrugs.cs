using Plague_Inc._2._0.Classes;
using Plague_Inc._2._0.Classes.TypesCS;
using Plague_Inc._2._0.Interfaceses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plague_Inc._2._0
{
    public partial class ChoiceDrugs : Form
    {
        MainCS disease = new MainCS();
        private Dictionary<Button, string> buttonStringMap;
        Image stab1 = global::Plague_Inc._2._0.Properties.Resources._2023_05_18_21_19_40,
            stab2 = global::Plague_Inc._2._0.Properties.Resources._2023_05_18_21_18_33,
            streng1 = global::Plague_Inc._2._0.Properties.Resources._2023_05_18_21_20_47,
            streng2 = global::Plague_Inc._2._0.Properties.Resources._2023_05_18_21_21_56,
            reas1 = global::Plague_Inc._2._0.Properties.Resources._2023_05_18_21_22_36,
            reas2 = global::Plague_Inc._2._0.Properties.Resources._2023_05_18_21_23_23,
            reas3 = global::Plague_Inc._2._0.Properties.Resources._2023_05_18_21_23_53;
        public ChoiceDrugs()
        {
            InitializeComponent();
        }
        internal ChoiceDrugs(MainCS mainCS)
        {
            disease = mainCS;
            InitializeComponent();
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

        private void ChoiceDrugs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        void ReTyry(bool bl)
        {
            if (!bl)
                MessageBox.Show("Сначала необходимо прокачать предыдущие навыки");
        }
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            if(disease.Score - 10 >=0)
            {
                bool flag = true;
                Button button = (Button)sender;
                bool IsOk()
                {
                    if(button.Equals(button2) && !disease.Drug.stability1)
                        return false;
                    else if(button.Equals(button4) && !disease.Drug.strengthening1)
                        return false;
                    else if(button.Equals(button6) && !disease.Drug.reassembly1)
                        return false;
                    else if(button.Equals(button7) && !disease.Drug.reassembly2)
                        return false;
                    return true;
                }
                if (button.Equals(button1) && !button1.BackgroundImage.Equals(stab1) && Helper())
                {
                    disease.Drug.stability1 = true;
                    button.BackgroundImage = stab1;
                }
                else if (button.Equals(button2) && disease.Drug.stability1 && !button2.BackgroundImage.Equals(stab2) && Helper())
                {
                    disease.Drug.stability2 = true; 
                    button.BackgroundImage = stab2;
                }
                    
                else if (button.Equals(button3) && !button3.BackgroundImage.Equals(streng1) && Helper())
                {
                    disease.Drug.strengthening1 = true;
                    button.BackgroundImage = streng1;
                }
                    
                else if (button.Equals(button4) && disease.Drug.strengthening1 && !button4.BackgroundImage.Equals(streng2) && Helper())
                {
                    disease.Drug.strengthening2 = true;
                    button.BackgroundImage = streng2;
                }
                    
                else if (button.Equals(button5) && !button5.BackgroundImage.Equals(reas1) && Helper())
                {
                    disease.Drug.reassembly1 = true;
                    button.BackgroundImage = reas1;
                }
                    
                else if (button.Equals(button6) && disease.Drug.reassembly1 && !button6.BackgroundImage.Equals(reas2) && Helper())
                {
                    disease.Drug.reassembly2 = true;
                    button.BackgroundImage = reas2;
                }
                    
                else if (button.Equals(button7) && disease.Drug.reassembly2 && !button7.BackgroundImage.Equals(reas3) && Helper())
                {
                    disease.Drug.reassembly3 = true;
                    button.BackgroundImage = reas3;
                }
                else
                {
                    flag = false;
                    ReTyry(IsOk());
                }
                if (flag)
                {
                    disease.Score -= 10;
                    lblScoreUpdate();
                }
            }
            else
            {
                MessageBox.Show("У вас недостаточно очков, для прокачки навыка обходимо минимум 10 очков");
            }
        }
        
        void lblScoreUpdate()
        {
            label2.Text = disease.Score.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            disease.Temp = disease.Score;   
            ChoiceSymptoms choiceSymptoms = new ChoiceSymptoms(disease);
            choiceSymptoms.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            disease.Score = disease.Temp;
            ChoiceClimate choiceClimate = new ChoiceClimate(disease);
            choiceClimate.Show();
            this.Hide();
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
        private void ChoiceDrugs_Load(object sender, EventArgs e)
        {
            disease.Temp = disease.Score;
            label2.Text = disease.Score.ToString();
            InitializeButtonMap();
            this.DoubleBuffered = true;
            button1.BackgroundImage =ImageWork.CreateDimmedImage(button1.BackgroundImage);
            button2.BackgroundImage = ImageWork.CreateDimmedImage(button2.BackgroundImage);
            button3.BackgroundImage = ImageWork.CreateDimmedImage(button3.BackgroundImage);
            button4.BackgroundImage = ImageWork.CreateDimmedImage(button4.BackgroundImage);
            button5.BackgroundImage = ImageWork.CreateDimmedImage(button5.BackgroundImage);
            button6.BackgroundImage = ImageWork.CreateDimmedImage(button6.BackgroundImage);
            button7.BackgroundImage = ImageWork.CreateDimmedImage(button7.BackgroundImage);
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
        private void InitializeButtonMap()
        {
            buttonStringMap = new Dictionary<Button, string>
        {
            { button1, "Развитие устойчивости к противовирусным препаратам 1 и 2 поколения. Повышается эффективность заражения в богатых странах."},
            { button2, "Развитие устойчивости к противовирусным препаратам 3 и 4 поколения. Повышается эффективность заражения в богатых странах." },
            { button3, "Патоген труднее поддается анализу в лаборатории. Уменьшается скорость будущих исследований."},
            { button4, "Патоген не воспроизводится в лабораторных условиях. Уменьшается скорость будущих исследований."},
            { button5, "Пересобраны цепочки ДНК инфекции. На разработку лекарства уйдет больше сил и времени."},
            { button6, "Появился новый штамм болезни, из-за чего требуется больше времени на разработку лекарства."},
            { button7, "Появилось множество штаммов болезни из-за чего требуется больше времени на разработку лекарства." }
        };
        }
        bool Helper()
        {
            DialogResult mb = MessageBox.Show("Хотите приобрести этот навык?",
                "Хотите приобрести этот навык?",
                MessageBoxButtons.YesNo);
            return mb == DialogResult.Yes;
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string type = buttonStringMap[clickedButton];
            label3.Text = type;
        }
    }
}
