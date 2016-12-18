using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class RepeatingEvent: Event
    {
        public TimeSpan Interval { get; set; }

        protected List<TimeSpan> repeats;

        public RepeatingEvent(
            string title, string descr, TimeSpan start, TimeSpan end,
            DateTime day, EventPriority priority, TimeSpan interval, List<IEventNotifier> notifiers): 
            base(title, descr, start, end, day, priority, notifiers)
        {
            if (interval.TotalMinutes < 5)
            {
                throw new Exception("Время повтора не должно быть меньше 5 минут!");
            }
            Interval = interval;

            repeats = new List<TimeSpan>();
            var time = start;
            while (time < end)
            {
                repeats.Add(time);
                time = time.Add(interval);
            }
        }

        public override void Notify()
        {
            base.Notify();
            isNotified = false;
            
            foreach (TimeSpan repeat in repeats)
            {
                var now = DateTime.Now;
                if (now.Minute == repeat.Minutes && now.Hour == repeat.Hours)
                    return;
            }

            isNotified = true;
        }
    }
}
