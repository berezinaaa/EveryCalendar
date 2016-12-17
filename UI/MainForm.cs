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
        public MainForm()
        {
            InitializeComponent();
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
                res.Add(new DateTime(1, 1, 1, i, i, 0), new List<Event>());
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
