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

        public UIEvent(Border uiDayBorder, Event ev, int numberEvents, int account)
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
            Color fillColor;
            switch (ev.Priority)
            {
                case EventPriority.Low:
                    fillColor = Color.White;
                    break;
                case EventPriority.Middle:
                    fillColor = Color.Orange;
                    break;
                case EventPriority.High:
                    fillColor = Color.OrangeRed;
                    break;
                default:
                    fillColor = Color.White;
                    break;
            }

            e.FillRectangle(new SolidBrush(fillColor), border.topLeftPoint.X + 1, border.topLeftPoint.Y + 1,
                border.width - 2, border.height);
            e.DrawRectangle(new Pen(Color.Black, 2), border.topLeftPoint.X + 1, border.topLeftPoint.Y + 1,
                border.width - 2, border.height);
            DrawText(e);
        }

        private void DrawText(Graphics e)
        {
            float rectHeight = border.height / 2;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font font = new Font("Arial", 10, GraphicsUnit.Pixel);
            e.DrawString(ev.Title, font, Brushes.Black,
                new RectangleF(border.topLeftPoint.X,
                border.topLeftPoint.Y, border.width, rectHeight), sf);
            e.DrawString(ev.Description, font, Brushes.Black, 
                new RectangleF(border.topLeftPoint.X,
                border.topLeftPoint.Y + rectHeight, border.width, rectHeight), sf);
            e.DrawLine(new Pen(Color.Black, 1), border.topLeftPoint.X, border.topLeftPoint.Y + rectHeight,
                border.topRightPoint.X, border.topRightPoint.Y + rectHeight);
        }

        public void clicked(Point mouse, Action<Event> openDialog)
        {
            if (mouse.X > border.topLeftPoint.X && mouse.X < border.topRightPoint.X &&
                mouse.Y > border.topRightPoint.Y && mouse.Y < border.bottomRightPoint.Y)
            {
                Console.WriteLine("Event clicked = " + ev.Title);
                openDialog(ev);
            }
        }
    }
}

