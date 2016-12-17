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
        bool isEditMode;

        // add new event mode
        public EditEventForm()
        {
            InitializeComponent();
            isEditMode = false;
        }

        // edit event mode
        public EditEventForm(Event ev): base()
        {
            isEditMode = true;
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

        private void completeButton_Click(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                this.ev = new Event();
            }

            ev.Title = titleTextBox.Text;
            ev.StartTime = startTimePicker.Value.TimeOfDay;
            ev.EndTime = endTimePicker.Value.TimeOfDay;
            ev.Day = dayPicker.Value;
            ev.Description = descriptionTextBox.Text;
            
            switch(priorityComboBox.SelectedIndex)
            {
                case 0:
                    ev.Priority = EventPriority.Low;
                    break;
                case 1:
                    ev.Priority = EventPriority.Middle;
                    break;
                default:
                    ev.Priority = EventPriority.High;
                    break;
            }

            var context = EventContext.GetInstance();
            if (!isEditMode)
            {
                context.Add(ev);
            }
            else
            {
                context.SaveChanges();
            }
            
            //TODO: notifications
        }
    }
}
