using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum EventPriority

    {
        Low, Middle, High
    }

    [Serializable]
    public class Event
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Day { get; set; }
        public EventPriority Priority { get; set; }
        public List<IEventNotifier> Notifiers { get; set; }

        protected bool isNotified;

        public Event()
        {
            Notifiers = new List<IEventNotifier>();
        }

        public Event(string title, string descr, TimeSpan start, TimeSpan end, DateTime day,
                     EventPriority priority, List<IEventNotifier> notifiers)
        {
            if (title.Equals("") || title == null)
            {
                throw new Exception("Название не должно быть пустым!");
            }
            Title = title;
            Description = descr;

            if (start >= end)
            {
                throw new Exception("Время начала события должно быть меньше конца!");
            }

            StartTime = start;
            EndTime = end;
            Day = day;
            Priority = priority;
            Notifiers = notifiers;
        }


        public string NotificationMessage
        {
            get
            {
                return "Напоминание о событии " + Title + "\n Время: " + 
                    timeString(StartTime) + " - " + timeString(EndTime);
            }
        }

        private string timeString(TimeSpan span)
        {
            string minutes = span.Minutes >= 10 ? span.Minutes.ToString() : "0" + span.Minutes.ToString();
            return span.Hours + ":" + minutes;
        }

        public bool ShouldNotify
        {
            get
            {
                var now = DateTime.Now;
                var nowTime = now.TimeOfDay;
                var date = now.Date;

                return now.Date == this.Day.Date &&
                    now.TimeOfDay >= this.StartTime &&
                    now.TimeOfDay <= this.EndTime &&
                    !isNotified;
            }
        }

        virtual public void Notify()
        {
            isNotified = true;
            foreach (IEventNotifier notifier in Notifiers)
            {
                notifier.Notify(this);
            }
        }
    }
}
