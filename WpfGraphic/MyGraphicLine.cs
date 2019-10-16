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
    class MyGraphicLine : MyLine
    {
        private Path line;
        private Path pointStart;
        private Path pointEnd;
        private Path pointCenter;
        private Canvas canvas;
        public bool IsCurrent { get; private set; }
        
        public MyGraphicLine(Canvas c) : base()
        {
            InitGraphicLine(c);
        }

        private void InitGraphicLine(Canvas c)
        {
            canvas = c;
            IsCurrent = false;

            line = new Path();
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 2;
            line.Data = lineGeometry;

            pointStart = new Path();
            pointStart.Stroke = Brushes.Red;
            pointStart.Fill = Brushes.Red;
            pointStart.Data = pointGeometry1;

            pointCenter = new Path();
            pointCenter.Stroke = Brushes.Red;
            pointCenter.Fill = Brushes.Red;
            pointCenter.Data = pointGeometry1;

            pointEnd = new Path();
            pointEnd.Stroke = Brushes.Red;
            pointEnd.Fill = Brushes.Red;
            pointEnd.Data = pointGeometry2;

            Draw();
        }
        
        //Рисует линию на холсте
        public void Draw()
        {
            canvas.Children.Add(line);
            canvas.Children.Add(pointStart);
            canvas.Children.Add(pointCenter);
            canvas.Children.Add(pointEnd);
        }

        //Удаляет линию с холста
        public void Remove()
        {
            canvas.Children.Remove(line);
            canvas.Children.Remove(pointStart);
            canvas.Children.Remove(pointCenter);
            canvas.Children.Remove(pointEnd);
        }

        //Выделяет линию как текущую либо как обычную
        public void TryDrawCurrent(Point p)
        {
            Vector Beg_point = new Vector(StartPoint, p);
            Vector End_point = new Vector(EndPoint, p);

            if (Math.Abs(this.A * p.X + this.B * p.Y + this.C) < 1000 && Math.Abs(Beg_point.GetScalarMul(End_point)) > 0.9)
            {
                line.Stroke = Brushes.PaleVioletRed;
                IsCurrent = true;
            }
            else
            {
                IsCurrent = false;
                line.Stroke = Brushes.Black;
            }
        }

        //Движение линии
        public void Move(Point mousePred, Point mouseTek)
        {
            double dX = mouseTek.X - mousePred.X;
            double dY = mouseTek.Y - mousePred.Y;

            double newX1, newY1, newX2, newY2;


            if (Math.Abs(mouseTek.X - EndPoint.X) < 15 && Math.Abs(mouseTek.Y - EndPoint.Y) < 15)
            {
                newX1 = EndPoint.X + dX;
                newY1 = EndPoint.Y + dY;
                if (newX1 > 0 && newY1 > 0 && newX1 < canvas.ActualWidth && newY1 < canvas.ActualHeight) EndPoint = new Point(newX1, newY1);
            }
            else 
            {
                if (Math.Abs(mouseTek.X - StartPoint.X) < 15 && Math.Abs(mouseTek.Y - StartPoint.Y) < 15)
                {
                    newX2 = StartPoint.X + dX;
                    newY2 = StartPoint.Y + dY;
                    if(newX2 > 0 && newY2 > 0 && newX2 < canvas.ActualWidth && newY2 < canvas.ActualHeight) StartPoint = new Point(newX2, newY2);
                }
                else
                {
                    newX1 = EndPoint.X + dX;
                    newY1 = EndPoint.Y + dY;
                    newX2 = StartPoint.X + dX;
                    newY2 = StartPoint.Y + dY;

                    if (newX1 > 0 && newY1 > 0 && newX1 < canvas.ActualWidth && newY1 < canvas.ActualHeight &&
                        newX2 > 0 && newY2 > 0 && newX2 < canvas.ActualWidth && newY2 < canvas.ActualHeight)
                    {
                        EndPoint = new Point(newX1, newY1);
                        StartPoint = new Point(newX2, newY2);
                    }
                }
            }
        }
    }
}
