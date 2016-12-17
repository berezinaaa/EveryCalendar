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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
    }
}
