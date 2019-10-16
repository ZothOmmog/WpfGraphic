using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Input;

namespace WpfGraphic
{
    class XOY
    {
        Path oX;
        Path oY;
        Canvas canvas;

        public XOY(Canvas canvas)
        {
            this.canvas = canvas;


        }

        private void Init()
        {
            LineGeometry lx = new LineGeometry(new Point(0, (int)canvas.Height / 2 + 1), new Point(canvas.Width, (int)canvas.Height / 2 + 1));
            LineGeometry ly = new LineGeometry(new Point((int)canvas.Width / 2 + 1, 0), new Point((int)canvas.Width / 2 + 1, canvas.Height));
        }
    }
}
