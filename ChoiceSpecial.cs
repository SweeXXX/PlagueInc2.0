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
    public partial class ChoiceSpecial : Form
    {
        MainCS disease = new MainCS ();
        private Dictionary<Button, string> buttonStringMap;
        public ChoiceSpecial()
        {
            InitializeComponent();
        }
        internal ChoiceSpecial(MainCS mainCS)
        {
            disease = mainCS;
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
        private void InitializeSpecial()
        {
            if ((disease.typeOfDisease is Virus))
            {
                (button1.Visible, button2.Visible, button3.Visible) = (true, true, true);
            }//+
            if ((disease.typeOfDisease is Bacterium))
            {
                (button5.Visible, button6.Visible, button7.Visible) = (true, true, true);
                button5.Visible= true;
            }//+
            if ((disease.typeOfDisease is BioWeapon))
            {

                (button22.Visible, button23.Visible, button24.Visible) = (true, true, true);
            }//+
            if ((disease.typeOfDisease is Fungus))
            {
                (button10.Visible, button11.Visible, button12.Visible) = (true, true, true);
            }//+
            if ((disease.typeOfDisease is Glist))
            {
                (button13.Visible, button14.Visible, button15.Visible) = (true, true, true);
            }//+
            if ((disease.typeOfDisease is NanoVirus))
            {
                (button18.Visible, button19.Visible, button20.Visible) = (true, true, true);
            }//+
            if ((disease.typeOfDisease is Prion))
            {
                (button16.Visible, button17.Visible, button228.Visible) = (true, true, true);
            }//+
        }
        void lblScoreUpdate()
        {
            label2.Text = disease.Score.ToString();
        }
        private void InitializeButtonMap()
        {
            buttonStringMap = new Dictionary<Button, string>
        {
            { button1,"Нестабильность ДНК повышает вероятность мутации."},
            { button2,"Цепь ДНК частично разрушается, повышая шанс мутации. "},
            { button3,"ДНК становится неустойчивой и фрагментированной, что ведет к повышению вероятности случайной мутации."},
            { button5,"У бактерии создается оболочка для защиты от любых климатических условий."},
            { button6,"Оболочка бактерии утолщается, что повышает ее живучесть в любых климатических условиях."},
            { button7,"Оболочка бактерии становится практически неуязвимой, что повышает ее живучесть в любых климатических условиях."},

            { button10,"Взрыв спор, распространяющий болезнь на новые страны."},
            { button11,"Выброс огромного количества спор в атмосферу."},
            { button12,"Укрепляет споры, позволяя им выживать в воздухе сколь угодно долго."},
            { button13,"Паразит лучше подстраивается под хозяина, снижая вероятность быть обнаруженным."},
            { button14,"ДНК паразита становится похожим на ДНК хозяина, что делает его менее заметным и более заразным. "},
            { button15,"Паразит проникает в мозг носителя, что делает его менее заметным и более заразным."},
            { button16,"Нервное расстройство снижает концентрацию - сложные задачи становится труднее решать."},
            { button17,"Аксональная опухоль вызывает дезориентацию и слабоумие, из-за чего замедляется разработка лекарства."},
            { button228,"Некроз клеток приводит к серьезному поражению памяти, из-за чего на решение сложных задач требуется значительно больше времени."},
            { button18,"Эволюционировавшие клетки болезни не восприимчивы к новейшим лекарствам. Рост заражения в богатых странах."},
            { button19,"Частичный взлом кода аварийного выключателя значительно снижает эффективность трансляции лечения."},
            { button20,"Вирус становится невосприимчивым к лечению на несколько недель из-за перегрузки перехватчика трансляции. Но вирус слабеет в долгосрочной перспективе."},
            { button22,"Отключение летальности био-оружия. Восстанавливается с течением времени."},
            { button23,"Отключение летальности био-оружия. Восстанавливается с течением времени."},
            { button24,"Отключение летальности био-оружия. Восстанавливается с течением времени."},
        };
        }
        bool Helper()
        {
            DialogResult mb = MessageBox.Show("Хотите приобрести этот навык?",
                "Хотите приобрести этот навык?",
                MessageBoxButtons.YesNo);
            return mb == DialogResult.Yes;
        }
        void InitializeDef()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button228.Visible = false;

            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;

            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
        }
        private void ChoiceSpecial_Load(object sender, EventArgs e)
        {
            //InitializeDef();
            lblScoreUpdate();
            InitializeButtonMap();
            InitializeSpecial();
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string type = buttonStringMap[clickedButton];
            label3.Text = type;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            disease.Score = disease.Temp;
            ChoiceSpecial choiceDrugs = new ChoiceSpecial(disease);
            choiceDrugs.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new FormTest(disease);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
