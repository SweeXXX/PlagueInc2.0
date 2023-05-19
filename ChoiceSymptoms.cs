using Plague_Inc._2._0.Classes;
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
    public partial class ChoiceSymptoms : Form
    {
        MainCS disease = new MainCS();
        private Dictionary<Button, bool> buttonBoolMap;
        private Dictionary<Button, string> buttonStringMap;
        public ChoiceSymptoms()
        {
            InitializeComponent();
        }
        internal ChoiceSymptoms(MainCS mainCS)
        {
            disease = mainCS;
            InitializeComponent();
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
        void Tr(Button button)
        {
            var mb = MessageBox.Show("Вы хотите выбрать этот симптом?", "Выбор симптома", MessageBoxButtons.YesNo);
            if (mb == DialogResult.Yes && disease.Score - 10 >= 0)
            {
                button.BackgroundImage = ImageWork.CreateOriginalImage(button.BackgroundImage);
                buttonBoolMap[button] = true;
                disease.countOfSymptoms++;
                disease.Score -= 10;
                label2.Text = disease.Score.ToString();
            }
            else if (mb == DialogResult.Yes && disease.Score - 10 < 0)
                MessageBox.Show("У вас не хватате очков(");
        }
        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            var type = buttonStringMap[clickedButton];
            label3.Text = type;
            if (e.Button == MouseButtons.Left && !buttonBoolMap[clickedButton])
            {
                
                Tr(clickedButton);
            }
        }
        private void InitializeBoolButtonMap()
        {
            buttonBoolMap = new Dictionary<Button, bool>
        {
            { button1,  false } ,
            { button2,  false},
            { button3,  false},
            { button4,  false},
            { button5,  false},
            { button6,  false},
            { button7,  false},
            { button8,  false},
            { button9,  false},
            { button10, false},
            { button11, false},
            { button12, false},
            { button13, false},
            { button14, false},
            { button15, false},
            { button16, false},
            { button17, false},
            { button18, false},
            { button19, false},
            { button20, false},
            { button21, false},
            { button22, false},
            { button23, false},
        };
        }
        private void InitializeButtonMap()
        {
            buttonStringMap = new Dictionary<Button, string>
        {
            { button1, "Раздраженная слизистая желудка приводит к дискомфорту. Небольшая вероятность заражения при поцелуях."},
            { button2, "Выброс инфицированного материала через рвоту увеличивает риск заражения." },
            { button3, "Заражение желудочно-кишечного тракта вызывает заражение через фекалии и смертельное обезвоживание. Наиболее уязвимы бедные страны."},
            { button4, "Полное растройство пищеварительной системы вызывает диарею, обезвоживание и смерть."},
            { button5, "Возможность заражения путем распространения патогена в окружающую среду, особенно в городах с высокой плотностью населения."},
            { button6, "Воспаление легочной ткани. Люди в холодных странах особенно уязвимы."},
            { button7, "Потенциально фатальное нарушение работы сердца вызывает расстройство дыхательной системы, что ведет к распространению инфекции по воздуху." },
            { button8, "Рубцы в легких вызывают одышку и сильнейший кашель. Смертельно при интенсивной физической нагрузке." },
            { button9, "Выделяемая при чихании слизь значительно увеличивает количество инфицированных." },
            { button10, "Повышение температуры и тяжелое обезвоживание может привести к летальному исходу." },
            { button11, "Заражение лимфоцитов подавляет иммунную систему и вызывает мутации. Может быть смертельно." },
            { button12, "Кожа покрывается болезненными волдырями. Слегка увеличивает скорость распространения инфекции." },
            { button13, "Усиленное потоотделение ускоряет распространение болезни из-за плохой гигиены. Наиболее опасно в холодных странах." },
            { button14, "Поражение эпидермиса приводит к появлению больших открытых ран и значительному росту заразности." },
            { button15, "Большие участки пораженнной ткани становятся фатальными источниками гангрены. Заразиться можно и от трупов." },
            { button16, "Неспособность нормально высыпаться делает людей раздражительными и менее продуктивными." },
            { button17, "Иррациональные заблуждения и недоверие жертв к другим людям делает невозмможным нормальное общение и сотрудничество." },
            { button18, "Приступы и консульсии с потерей сознания уменьшают способность пациента функционировать самостоятельно. Иногда смертельно." },
            { button19, "невропатическое действие возбудителя в лобной коре вызывает тяжелые эмоциональные и поведенческие отклонения. Очень трудно вылечить." },
            { button20, "Появляются болезненные припухлости, содержащие патоген. Их возможный разрыв приводит к улучшению распространения болезни." },
            { button21, "Повышается склонность к аллергическим реакциям, способным расстроить иммунную сиситему. Особенно уязвимы богатые регионы." },
            { button22, "Воспаление нарушает жизненные процессы. опухоль может затруднять дыхание, приводя к смерти. " },
            { button23, "Болезнь разрушает моторные нейроны, вызывая паралич. Трудно лечить, возможны летальные исходы." }
        };
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
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string type = buttonStringMap[clickedButton];
            label3.Text = type;
        }
        private void ChoiceSymptoms_Load(object sender, EventArgs e)
        {
            disease.Temp = disease.Score;
            label2.Text = disease.Score.ToString();
            InitializeButtonMap();
            InitializeBoolButtonMap();
            InitializeImages(); 
        }
        private void InitializeImages()
        {
            button1.BackgroundImage = ImageWork.CreateDimmedImage(button1.BackgroundImage);
            button2.BackgroundImage = ImageWork.CreateDimmedImage(button2.BackgroundImage);
            button3.BackgroundImage = ImageWork.CreateDimmedImage(button3.BackgroundImage);
            button4.BackgroundImage = ImageWork.CreateDimmedImage(button4.BackgroundImage);
            button5.BackgroundImage = ImageWork.CreateDimmedImage(button5.BackgroundImage);
            button6.BackgroundImage = ImageWork.CreateDimmedImage(button6.BackgroundImage);


            button8.BackgroundImage = ImageWork.CreateDimmedImage(button8.BackgroundImage);
             button9.BackgroundImage = ImageWork.CreateDimmedImage( button9.BackgroundImage);
            button10.BackgroundImage = ImageWork.CreateDimmedImage(button10.BackgroundImage);
            button11.BackgroundImage = ImageWork.CreateDimmedImage(button11.BackgroundImage);
            button12.BackgroundImage = ImageWork.CreateDimmedImage(button12.BackgroundImage);
            button13.BackgroundImage = ImageWork.CreateDimmedImage(button13.BackgroundImage);
            button14.BackgroundImage = ImageWork.CreateDimmedImage(button14.BackgroundImage);


            button15.BackgroundImage = ImageWork.CreateDimmedImage(button15.BackgroundImage);
            button16.BackgroundImage = ImageWork.CreateDimmedImage(button16.BackgroundImage);
            button17.BackgroundImage = ImageWork.CreateDimmedImage(button17.BackgroundImage);
            button18.BackgroundImage = ImageWork.CreateDimmedImage(button18.BackgroundImage);
            button19.BackgroundImage = ImageWork.CreateDimmedImage(button19.BackgroundImage);
            button20.BackgroundImage = ImageWork.CreateDimmedImage(button20.BackgroundImage);
            button21.BackgroundImage = ImageWork.CreateDimmedImage(button21.BackgroundImage);
            button22.BackgroundImage = ImageWork.CreateDimmedImage(button22.BackgroundImage);
            button23.BackgroundImage = ImageWork.CreateDimmedImage(button23.BackgroundImage);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new ChoiceSpecial(disease);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            disease.Score = disease.Temp;
            ChoiceDrugs choiceDrugs = new ChoiceDrugs(disease);
            choiceDrugs.Show();
            this.Hide();
        }

        private void ChoiceSymptoms_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
