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

    public class Event
    {
        [Key]
        public int eventId { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Day { get; set; }
        public EventPriority Priority { get; set; }

        public Event(string title, string descr, TimeSpan start, TimeSpan end, DateTime day, EventPriority priority)
        {
            Title = title;
            Description = descr;
            StartTime = start;
            EndTime = end;
            Day = day;
            Priority = priority;
        }
        public EventDataSource DataSource() {
            return new EventDataSource(this);
        }

        public string NotificationMessage
        {
            get
            {
                return "Время " + StartTime + ". Начинается событие " + Title;
            }
        }
    }

    public class EventDataSource
    {
        private Event calendarEvent;
         
        public string Time
        {
            get
            {
                return calendarEvent.StartTime.ToString() + " - " + calendarEvent.EndTime.ToString();
            }
        }
        public string Title { get { return calendarEvent.Title; } }

        public EventDataSource(Event calendarEvent)
        {
            this.calendarEvent = calendarEvent;
        }
    }
}
