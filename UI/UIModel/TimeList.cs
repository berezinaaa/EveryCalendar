using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UI.UIModel
{
    class TimeList
    {
        public TimeList(Border border, Border weekBorder)
        {
            this.border = border;
            this.weekBorder = weekBorder;
        }
        public Border border { get; set; }
        private Border weekBorder;

        public void Draw(Graphics e)
        {
            float rectHeight = border.height / 12.0f;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font font = new Font("Arial", rectHeight / 2, GraphicsUnit.Pixel);
            for (int i = 0; i < 12; i++)
            {
                e.DrawString(i + ":00", font, Brushes.Black,
                    new RectangleF(border.topLeftPoint.X, 
                    border.topLeftPoint.Y + rectHeight * i, border.width, rectHeight), sf);
            }
        }
    }
}
