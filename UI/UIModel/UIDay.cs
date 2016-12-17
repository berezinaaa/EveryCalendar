using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Drawing;

namespace UI.UIModel
{
    class UIDay
    {
        public Border border { get; set; }
        private List<UIEvent> events;
        public DateTime date;
        public UIDay(Border border, DateTime date)
        {
            events = new List<UIEvent>();
            this.border = border;
            this.date = date;
        }

        public void AddEvent(UIEvent ev)
        {
            events.Add(ev);
        }

        public void RemoveEvent(UIEvent ev)
        {
            events.Remove(ev);
        }

        public void Draw(Graphics e)
        {
            foreach (UIEvent ev in events)
            {
                ev.Draw(e);
            }
        }
    }
}
