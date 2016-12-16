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

        public RepeatingEvent(
            string title, 
            string descr, 
            TimeSpan start, 
            TimeSpan end,
            DateTime day,
            EventPriority priority,
            TimeSpan interval): 
            base(title, descr, start, end, day, priority)
        {
            Interval = interval;
        }
    }
}
