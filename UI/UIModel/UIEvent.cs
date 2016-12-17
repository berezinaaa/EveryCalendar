using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Drawing;

namespace UI.UIModel
{
    class UIEvent
    {
        public Event ev { get; set; }
        public Border border { get; set; }

        public UIEvent (Border uiDayBorder, Event ev, int numberEvents, int account)
        {
            this.ev = ev;
            int startMinutes = ev.StartTime.Hours * 60 + ev.StartTime.Minutes;
            int duration = startMinutes + ev.EndTime.Hours * 60 + +ev.EndTime.Minutes;
            float proportion = (float)duration / (float)(24 * 60);
            float height = uiDayBorder.height * proportion;
            int y = (int)(uiDayBorder.topLeftPoint.Y + uiDayBorder.height * proportion);
            float width = uiDayBorder.width / numberEvents;
            this.border = new Border((int)(uiDayBorder.topLeftPoint.X + account * width), y, width, height);
        }

        public void Draw(Graphics e)
        {

        }
    }
}
