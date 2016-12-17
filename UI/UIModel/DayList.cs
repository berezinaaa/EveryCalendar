using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UI.UIModel
{
    class DayList
    {
        public DayList(Border border, Border weekBorder, List<UIDay> days)
        {
            this.border = border;
            this.days = days;
            this.weekBorder = weekBorder;
        }
        public Border border { get; set; }
        private List<UIDay> days;
        private Border weekBorder;

        public void Draw(Graphics e)
        {
            Pen pen = new Pen(Color.Black, 1);
            for (int i = 0; i < days.Count; i++)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                Font font = new Font("Arial", border.height / 2, GraphicsUnit.Pixel);

                e.DrawLine(pen, days[i].border.topRightPoint.X, border.topLeftPoint.Y,
                    days[i].border.topRightPoint.X, days[i].border.bottomLeftPoint.Y);

                RectangleF rect = new RectangleF((float)days[i].border.topLeftPoint.X,
                    (float)border.topLeftPoint.Y, border.width / 7.0f, (float)border.height);
                e.DrawString(days[i].date.Date.ToString(), font, Brushes.Black, rect, sf);
            }
        }
    }
}
