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
        private EventManager manager;
        private UIModel.UIWeek week;

        public MainForm()
        {
            InitializeComponent();

            manager = EventManager.GetInstance();
            timer1.Enabled = true;
            doSomething();
            button2.Text = "Назад";
            button3.Text = "Далее";
        }

        public void doSomething()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = flowLayoutPanel1.Width * 2;
            pictureBox.Height = flowLayoutPanel1.Height * 2;
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            flowLayoutPanel1.Controls.Add(pictureBox);
            pictureBox.MouseDoubleClick += new MouseEventHandler(pictureBox1DoubleClick);
            week = new UIModel.UIWeek(new UIModel.Border(0, 0,
                pictureBox.Width, pictureBox.Height), manager.WeekEventsFromStartDate(DateTime.Today) , pictureBox);
            DrawCalendar();
        }

        private void pictureBox1DoubleClick (object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            week.clicked(coordinates, (ev) => {
                var editForm = new EditEventForm(ev, week);
                editForm.FormClosing += new FormClosingEventHandler(this.EditFrom_FormClosing);
                editForm.ShowDialog();
            });

        }

        private void EditFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            DrawCalendar();
            week = new UIModel.UIWeek(week.border, 
            manager.WeekEventsFromStartDate(week.startDay), week.pictureBox);
        }

       

        private void DrawCalendar()
        {
            //week = new UIModel.UIWeek(week.border,
             //   EventManager.GetInstance().WeekEventsFromStartDate(week.startDay),
              //  week.pictureBox);
            week.Draw();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //var telegram = TelegramManager.GetInstance();
            //telegram.SendMessage("hello world");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var editForm = new EditEventForm(week);
            editForm.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            manager.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            manager.CheckEvents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime day = week.startDay;
            day = day.AddDays(-7);
            week = new UIModel.UIWeek(week.border,
                EventManager.GetInstance().WeekEventsFromStartDate(day),
                week.pictureBox);
            DrawCalendar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime day = week.startDay;
            day = day.AddDays(7);
            week = new UIModel.UIWeek(week.border,
                EventManager.GetInstance().WeekEventsFromStartDate(day),
                week.pictureBox);
            DrawCalendar();
        }
    }
}
