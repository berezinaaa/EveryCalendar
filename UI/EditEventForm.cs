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
    public partial class EditEventForm : Form
    {
        Event ev;

        public EditEventForm()
        {
            InitializeComponent();
        }

        public EditEventForm(Event ev): base()
        {
            this.ev = ev;
            titleTextBox.Text = ev.Title;
            var day = ev.Day;
            startTimePicker.Value = day.AddSeconds(ev.StartTime.TotalSeconds);
            endTimePicker.Value = day.AddSeconds(ev.EndTime.TotalSeconds);
            dayPicker.Value = day;
            descriptionTextBox.Text = ev.Description;

            priorityComboBox.SelectedIndex = (int)ev.Priority;

            //TODO: notifications
        }

        private void EditEventForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
