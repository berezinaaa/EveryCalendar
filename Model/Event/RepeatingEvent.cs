using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class RepeatingEvent: Event
    {
        TimeSpan Interval { get; set; }
        protected int maxRepeatingCount;
        protected int repeatingCount;

        public RepeatingEvent() { }

        public RepeatingEvent(
            string title, string descr, TimeSpan start, TimeSpan end,
            DateTime day, EventPriority priority, TimeSpan interval, List<IEventNotifier> notifiers): 
            base(title, descr, start, end, day, priority,  notifiers)
        {
            Interval = interval;

            var time = start;
            while (time < end)
            {
                maxRepeatingCount++;
                time = time.Add(Interval);
            }
        }

        override public void Notify()
        {
            base.Notify();
            isNotified = false;
            
            if (repeatingCount < maxRepeatingCount)
            {
                repeatingCount++;
            }
            else
            {
                isNotified = true;
            }
        }
    }
}
