using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Model
{
    public class EventManager
    {
        private static EventManager instance;

        public static EventManager GetInstance()
        {
            if (instance == null)
            {
                instance = new EventManager();
            }
            return instance;
        }

        public EventManager()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("events1.bin", FileMode.Open, FileAccess.Read, FileShare.None);
                events = (List<Event>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                this.events = new List<Event>();
            }
        }

        public List<Event> events { get; set; }

        public void Add(Event calendarEvent)
        {
            this.events.Add(calendarEvent);
        }

        public void Remove(Event calendarEvent)
        {
            this.events.Remove(calendarEvent);
        }

        public void CheckEvents()
        {
            var todayEvents = EventsForDate(DateTime.Now.Date);
            var eventsToDelete = new List<Event>();

            foreach (Event e in todayEvents)
            {
                if (e.ShouldNotify)
                {
                    e.Notify();
                    eventsToDelete.Add(e);
                }
            }

            foreach (Event e in eventsToDelete)
            {
                todayEvents.Remove(e);
            }
        }

        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("events1.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, events);
            }
        }

        public Dictionary<DateTime, List<Event>> WeekEventsFromStartDate(DateTime startDay)
        {
            var day = startDay;

            var result = new Dictionary<DateTime, List<Event>>();
            for (int i = 0; i < 7; i++)
            {
                result.Add(day.Date, EventsForDate(day.Date));
                day = day.AddDays(1);
            }

            return result;
        }

        public List<Event> EventsForDate(DateTime date)
        {
            try
            {
                var result = from ev in events
                             where ev.Day == date
                             select ev;

                return result.OrderBy(ev => ev.StartTime).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return new List<Event>();
            }
        }
    }
}
