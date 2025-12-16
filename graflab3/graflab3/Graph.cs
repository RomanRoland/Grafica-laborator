using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graflab3
{
    public class Graph
    {
        public double X, Y;
        public Graph(double x, double y) 
        {
            X = x; 
            Y = y;
        }
        public PointF ToPointF() => new PointF((float)X, (float)Y);
        public Point ToPoint() => new Point ((int)X, (int)Y);
        public void Draw(Graphics handler)
        {
            Point point = this.ToPoint();
            handler.DrawEllipse(Pens.Black, point.X - 2, point.Y - 2, 5, 5);
        }
    }
}
