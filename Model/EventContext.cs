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


    }
}
