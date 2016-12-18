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
    public class UIWeek
    {
        public Border border { get; set; }
        private List<UIDay> uiDays;
        private TimeList timeList;
        private DayList dayList;
        public Graphics e { get; }
        public DateTime startDay { get; }
        public PictureBox pictureBox;
        public UIWeek(Border border, Dictionary<DateTime, List<Event>> events, PictureBox pB)
        {
            this.border = border;
            this.pictureBox = pB;
            uiDays = new List<UIDay>();
            this.e = Graphics.FromImage(pB.Image);
            float indentX = border.width / 10.0f;
            float indentY = border.height / 15.0f;
            timeList = new TimeList(new Border(border.topLeftPoint.X, (int)indentY, border.width / 10,
                border.height - indentY), border);
            dayList = new DayList(new Border((int)indentX, border.topLeftPoint.Y, border.width - indentX,
                indentY), border, uiDays);
            setUIDays(events);
            this.startDay = uiDays[0].date;
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

        public void clicked(Point mouse, Action<Event> openDialog)
        {
            foreach (UIDay uiDay in uiDays)
            {
                uiDay.clicked(mouse, openDialog);
            }
        }

        public void Draw()
        { 
            e.Clear(Color.White);
            DrawLines(e);
            timeList.Draw(e);
            dayList.Draw(e);
            foreach (UIDay uiDay in uiDays)
            {
                uiDay.Draw(e);
            }

            pictureBox.Refresh();
        }

        private void DrawLines(Graphics e)
        {
            float rectHeight = timeList.border.height / 24.0f;
            for (int i = 0; i < 24; i++)
            {
                Color c = Color.LightGray;
                if (i % 2 == 1) { c = Color.LightBlue; }

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
