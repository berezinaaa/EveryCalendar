using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class EventContext: DbContext
    {
        private static EventContext instance;

        public static EventContext GetInstance()
        {
            if (instance == null)
            {
                instance = new EventContext();
            }
            return instance;
        }

        public DbSet<Event> events { get; set; }

        public void Add(Event calendarEvent)
        {
            this.events.Add(calendarEvent);
            this.SaveChanges();
        }

        public void Remove(Event calendarEvent)
        {
            this.events.Remove(calendarEvent);
            this.SaveChanges();
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
