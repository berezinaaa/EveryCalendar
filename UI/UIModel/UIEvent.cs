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
            float minutesInDay = 24f * 60f;
            int duration = ev.EndTime.Minutes - startMinutes + ev.EndTime.Hours * 60;
            float proportion = (float)duration / minutesInDay;
            float height = uiDayBorder.height * proportion;
            int y = (int)(uiDayBorder.topLeftPoint.Y + startMinutes / minutesInDay * uiDayBorder.height);
            float width = uiDayBorder.width / numberEvents;
            this.border = new Border((int)(uiDayBorder.topLeftPoint.X + account * width), y, width, height);
        }

        public void Draw(Graphics e)
        {
            Console.WriteLine("border.topLeftPoint.X = " + border.topLeftPoint.X);
            Console.WriteLine("border.topLeftPoint.Y = " + border.topLeftPoint.Y);
            Console.WriteLine("width" + border.width);
            Console.WriteLine("height" + border.height + "\n");
            e.DrawRectangle(new Pen(Color.Red, 2), border.topLeftPoint.X + 1, border.topLeftPoint.Y + 1,
                border.width - 2, border.height - 2);
        }
    }
}
