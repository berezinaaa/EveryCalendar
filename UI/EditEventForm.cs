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
using Model.Notifiers;

namespace UI
{
    public partial class EditEventForm : Form
    {
        private Event ev;
        bool isEditMode;
        private UIModel.UIWeek week;
        // add new event mode
        public EditEventForm(UIModel.UIWeek week)
        {
            InitializeComponent();
            isEditMode = false;
            this.week = week;
            button1.Enabled = false;
            button1.Visible = false;
            completeButton.Text = "Добавить";
            Text = "Новое событие";
            priorityComboBox.SelectedIndex = 1;
            //this.owner = owner;
        }

        // edit event mode  
        public EditEventForm(Event ev, UIModel.UIWeek week) : base()
        {
            InitializeComponent();
            this.week = week;
            isEditMode = true;
            this.ev = ev;

            Fill(ev);

            priorityComboBox.SelectedIndex = (int)ev.Priority;
            completeButton.Text = "Изменить";
            button1.Text = "Удалить";
            Text = "Редактирование события";
            //TODO: notifications
        }

        private void Fill(Event ev)
        {
            titleTextBox.Text = ev.Title;
            var day = ev.Day;
            startTimePicker.Value = day.AddSeconds(ev.StartTime.TotalSeconds);
            endTimePicker.Value = day.AddSeconds(ev.EndTime.TotalSeconds);
            dayPicker.Value = day;
            descriptionTextBox.Text = ev.Description;

            priorityComboBox.SelectedIndex = (int)ev.Priority;

            bool visual = false;
            bool telegram = false;
            bool sms = false;

            foreach (IEventNotifier notifier in ev.Notifiers)
            {
                if (notifier is SmsNotifier)
                {
                    sms = true;
                }
                if (notifier is TelegramNotifier)
                {
                    telegram = true;
                }
                if (notifier is VisualNotifier)
                {
                    visual = true;
                }
            }

            if (!TelegramManager.GetInstance().isLogin)
            {
                telegramCheckBox.Enabled = false;
            }

            visualCheckbox.Checked = visual;
            smsCheckBox.Checked = sms;
            telegramCheckBox.Checked = telegram;

            if (ev is RepeatingEvent)
            {
                var e = (RepeatingEvent)ev;
                repeatCheckbox.Checked = true;
                repeatTimePicker.Value = day.AddSeconds(e.Interval.TotalSeconds);
            }
            else
            {
                repeatCheckbox.Checked = false;
            }
        }

        private void EditEventForm_Load(object sender, EventArgs e)
        {
            
        }

        private void completeButton_Click(object sender, EventArgs e)
        {
            var title = titleTextBox.Text;
            var startTime = startTimePicker.Value.TimeOfDay;
            var endTime = endTimePicker.Value.TimeOfDay;
            var day = dayPicker.Value.Date;
            var description = descriptionTextBox.Text;
            var priority = EventPriority.Middle;

            switch(priorityComboBox.SelectedIndex)
            {
                case 0:
                    priority = EventPriority.Low;
                    break;
                case 1:
                    priority = EventPriority.Middle;
                    break;
                default:
                    priority = EventPriority.High;
                    break;
            }

            var notifiers = new List<IEventNotifier>();

            if (visualCheckbox.Checked)
            {
                notifiers.Add(new VisualNotifier());
            }
            if (telegramCheckBox.Checked)
            {
                notifiers.Add(new TelegramNotifier());
            }
            if (smsCheckBox.Checked)
            {
                notifiers.Add(new SmsNotifier());
            }

            var manager = EventManager.GetInstance();
            if (isEditMode)
            {
                manager.Remove(ev);
            }

            try
            {
                if (repeatCheckbox.Checked)
                {
                    var interval = repeatTimePicker.Value.TimeOfDay;
                    ev = new RepeatingEvent(title, description, startTime, endTime, day,
                                                            priority, interval, notifiers);
                }
                else
                {
                    ev = new Event(title, description, startTime, endTime, day,
                                                            priority, notifiers);
                }

                manager.Add(ev);

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void EditEventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            week = new UIModel.UIWeek(week.border,
                EventManager.GetInstance().WeekEventsFromStartDate(week.startDay),
                week.pictureBox);
            week.Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var manager = EventManager.GetInstance();
            manager.Remove(ev);
            this.Close();
        }
    }
}
