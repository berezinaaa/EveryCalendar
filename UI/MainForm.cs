using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace UI
{
    public partial class MainForm : Form
    {
        private EventContext context;

        public MainForm()
        {
            InitializeComponent();

            context = EventContext.GetInstance();

            doSomething();
        }

        public void doSomething()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = flowLayoutPanel1.Width * 2;
            pictureBox.Height = flowLayoutPanel1.Height * 2;
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            flowLayoutPanel1.Controls.Add(pictureBox);
            DrawCalendar(pictureBox);
            pictureBox.MouseDoubleClick += new MouseEventHandler(pictureBox1DoubleClick);

        }

        private void pictureBox1DoubleClick (object sender, EventArgs e)
        {
            Application.Run(new EditEventForm());
        }

        //TODO: DELETE
        public Dictionary<DateTime, List<Event>> fillDay()
        {
            Dictionary<DateTime, List<Event>> res = new Dictionary<DateTime, List<Event>>();
            for (int i = 0; i < 7; i++)
            {
                List<Event> ev = new List<Event>();
                TimeSpan startTime = new TimeSpan(11, 30, 0);
                TimeSpan endTime = new TimeSpan(15, 30, 0);
                ev.Add(new Event("Проснуться", "Очень рано, но не слишком", startTime, endTime,
                    DateTime.Today, EventPriority.High, new List<IEventNotifier>()));
                endTime = new TimeSpan(18, 30, 0);
                ev.Add(new Event("Проснуться", "Очень рано, но не слишком", startTime, endTime,
                    DateTime.Today, EventPriority.High, new List<IEventNotifier>()));

                DateTime date = DateTime.Today;
                res.Add(date.AddDays(i), ev);
            }

            return res;
        }

        private void DrawCalendar(PictureBox pictureBox)
        {
            UIModel.UIWeek week = new UIModel.UIWeek(new UIModel.Border(0, 0,
                pictureBox.Width, pictureBox.Height), fillDay());
            week.Draw(Graphics.FromImage(pictureBox.Image));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //var telegram = TelegramManager.GetInstance();
            //telegram.SendMessage("hello world");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var editForm = new EditEventForm();
            editForm.ShowDialog();
        }
    }
}
