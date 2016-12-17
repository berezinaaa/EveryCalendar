using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UI.UIModel
{
    class Border
    {
        public Point topLeftPoint { get; set; }
        public Point topRightPoint { get; set; }
        public Point bottomLeftPoint { get; set; }
        public Point bottomRightPoint { get; set; }
        public float width { get; set; }
        public float height { get; set; }

        public Border (int x, int y, float width, float height)
        {
            topLeftPoint = new Point(x, y);
            topRightPoint = new Point((int)(x + width), y);
            bottomLeftPoint = new Point(x, (int)(y + height));
            bottomRightPoint = new Point((int)(x + width), (int)(y + height));
            this.width = width;
            this.height = height;
        }
    }
}
