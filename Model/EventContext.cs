using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    class EventContext: DbContext
    {
        
        public DbSet<Event> events { get; set; }

        public void Add(Event calendarEvent)
        {
            this.Add(calendarEvent);
            this.SaveChanges();
        }

        public void Remove(Event calendarEvent)
        {
            this.Remove(calendarEvent);
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

        public List<Event> EventsForDate(DateTime date)
        {
            var result = from ev in events
                         where ev.Day.Date == date
                         select ev;
            return result.OrderBy(ev => ev.StartTime).ToList();
        }
    }
}
