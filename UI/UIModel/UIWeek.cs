using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Model;
namespace UI.UIModel
{
    class UIWeek
    {
        public Border border { get; set; }
        private List<UIDay> uiDays;
        private TimeList timeList;
        private DayList dayList;

        public UIWeek(Border border, Dictionary<DateTime, List<Event>> events)
        {
            this.border = border;
            uiDays = new List<UIDay>();

            float indentX = border.width / 10.0f;
            float indentY = border.height / 15.0f;
            timeList = new TimeList(new Border(border.topLeftPoint.X, (int)indentY, border.width / 10,
                border.height - indentY), border);
            dayList = new DayList(new Border((int)indentX, border.topLeftPoint.Y, border.width - indentX,
                indentY), border, uiDays);
            setUIDays(events);
            
        }

        private void setUIDays(Dictionary<DateTime, List<Event>> events)
        {
            float dayWith = dayList.border.width / 7.0f;
            foreach (DateTime date in events.Keys)
            {
                UIDay newDay= new UIDay(new Border((int)(dayList.border.bottomLeftPoint.X + dayWith * uiDays.Count), 
                    dayList.border.bottomLeftPoint.Y, dayWith, timeList.border.height), date);
                for (int i = 0; i < events[date].Count; i++)
                {
                    UIEvent uiEvent = new UIEvent(newDay.border, events[date][i], events[date].Count, i);
                    newDay.AddEvent(uiEvent);
                }
                uiDays.Add(newDay);
            }
        }

        public void Draw(Graphics e)
        {
            e.Clear(Color.White);
            DrawLines(e);
            timeList.Draw(e);
            dayList.Draw(e);
            foreach (UIDay uiDay in uiDays)
            {
                uiDay.Draw(e);
            }
        }

        private void DrawLines(Graphics e)
        {
            float rectHeight = timeList.border.height / 12.0f;
            for (int i = 0; i < 12; i++)
            {
                Color c = Color.SaddleBrown;
                if (i % 2 == 1)
                {
                    c = Color.Gray;
                }
                e.FillRectangle(new SolidBrush(c),
                 
                    new RectangleF(border.topLeftPoint.X, timeList.border.topLeftPoint.Y + i * rectHeight, border.width, rectHeight));
                Pen pen = new Pen(Color.Black, 1);
                for (int j = 1; j < 3; j++)
                {
                    e.DrawLine(pen, timeList.border.topRightPoint.X, 
                        timeList.border.topLeftPoint.Y + i * rectHeight + j * rectHeight / 3,
                        border.topRightPoint.X,
                        timeList.border.topRightPoint.Y + i * rectHeight + j * rectHeight / 3);
                }
                e.DrawLine(pen, border.topLeftPoint.X, timeList.border.topLeftPoint.Y + i * rectHeight,
                    border.topRightPoint.X, timeList.border.topLeftPoint.Y + i * rectHeight);
                e.DrawLine(pen, timeList.border.topRightPoint.X, border.topLeftPoint.Y, 
                    timeList.border.topRightPoint.X, timeList.border.bottomRightPoint.Y);
            }
        }
    }
}
