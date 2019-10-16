using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace WpfGraphic
{
    class Vector
    {
        Point pointBegin;
        Point pointEnd;

        public Point PointVector
        {
            get
            {
                return new Point(pointEnd.X - pointBegin.X, pointEnd.Y - pointBegin.Y);
            }
        }

        public Vector(Point b, Point e)
        {
            pointBegin = b;
            pointEnd = e;
        }

        //Векторное произведение векторов
        public double GetVectMul(Vector v)
        {
            return this.PointVector.X * v.PointVector.Y - this.PointVector.Y * v.PointVector.X;
        }

        //Скалярное произведение двух векторов
        public double GetScalarMul(Vector v)
        {
            return (this.PointVector.X * v.PointVector.X + this.PointVector.Y * v.PointVector.Y) /
                (Math.Sqrt(Math.Pow(this.PointVector.X, 2) + Math.Pow(this.PointVector.Y, 2)) * 
                Math.Sqrt(Math.Pow(v.PointVector.X, 2) + Math.Pow(v.PointVector.Y, 2)));
        }

    }
}
