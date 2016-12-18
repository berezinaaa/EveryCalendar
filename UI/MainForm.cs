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
        EventContext context;

        public MainForm()
        {
            InitializeComponent();

            context = EventContext.GetInstance();
            timer.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer.Tick += new EventHandler(TimerTicked);
        }

        void TimerTicked(object Sender, EventArgs e)
        {
            context.CheckEvents();
        }

        private void UpdateEvents()
        {
            var events = EventContext.GetInstance().EventsForDate(DateTime.Now.Date);
            List<EventDataSource> eventsDS = events.Select(ev => ev.DataSource()).ToList();
            dataGridView1.DataSource = eventsDS;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var editForm = new EditEventForm();
            editForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateEvents();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new TelegramLoginForm();
            form.ShowDialog();
        }
    }
}
