using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace WpfGraphic
{
    class MyLine
    {
        protected LineGeometry lineGeometry; //Сама линия
        protected EllipseGeometry pointGeometry1; //точка начала линии
        protected EllipseGeometry pointGeometry2; //точка конца линии
        protected double[] abc; //Коэффиценты уравнения прямой

        public Point StartPoint
        {
            get
            {
                try { return lineGeometry.StartPoint; }
                catch (Exception ex) { throw ex; }
            }

            set
            {
                try
                {
                    lineGeometry.StartPoint = value;
                    pointGeometry1.Center = lineGeometry.StartPoint;
                    CalcABC();
                }
                catch (Exception ex) { throw ex; }
            }
        }
        public Point EndPoint
        {
            get
            {
                try { return lineGeometry.EndPoint; }
                catch (Exception ex) { throw ex; }
            }

            set
            {
                try
                {
                    lineGeometry.EndPoint = value;
                    pointGeometry2.Center = lineGeometry.EndPoint;
                    CalcABC();
                }
                catch (Exception ex) { throw ex; }
            }
        }

        public double A
        {
            get
            {
                return abc[0];
            }

            private set
            {
                abc[0] = value;
            }
        }
        public double B
        {
            get
            {
                return abc[1];
            }

            private set
            {
                abc[1] = value;
            }
        }
        public double C
        {
            get
            {
                return abc[2];
            }

            private set
            {
                abc[2] = value;
            }
        }

        //Инициализация линии со случайными координатами
        public MyLine()
        {
            Random rnd = new Random();
            double x1 = 200 + rnd.Next(50);
            double y1 = 300 + rnd.Next(50);
            double x2 = 350 + rnd.Next(50);
            double y2 = 250 + rnd.Next(50);

            InitLine(x1, y1, x2, y2);
        }

        public MyLine(double x1, double y1, double x2, double y2)
        {
            InitLine(x1, y1, x2, y2);
        }

        //Инициализирует линию
        private void InitLine(double x1, double y1, double x2, double y2)
        {
            lineGeometry = new LineGeometry(new Point(x1, y1), new Point(x2, y2));

            pointGeometry1 = new EllipseGeometry(new Point(x1, y1), 3, 3);
            pointGeometry2 = new EllipseGeometry(new Point(x2, y2), 3, 3);

            abc = new double[3];

            CalcABC();
        }

        //Пересчитывает коэффиценты прямой после изменения точек
        private void CalcABC()
        {
            A = StartPoint.Y - EndPoint.Y;
            B = EndPoint.X - StartPoint.X;
            C = StartPoint.X * EndPoint.Y - EndPoint.X * StartPoint.Y;
        }
    }
}