using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCon_28
{
    class Shape
    {
        public Shape(string Base)
        {
            BaseText = Base;

            List<int> Nums = new List<int>();

            int count = 0;
            string tex = "";
            for(int i = 0;Base.Length > i; i++)
            {
                char c = Base[i];

                if (c == ';')
                {
                    if (count == 0) VertexCount = int.Parse(tex);
                    else Nums.Add(int.Parse(tex));

                    count++;
                    tex = "";
                }
                else
                    tex += c;
            }

            Nums.Add(int.Parse(tex));

            Points = new System.Drawing.Point[VertexCount];
            int t = 0;
            for(int i = 0;Nums.Count > i; i++)
            {
                if((i + 1) % 2 == 0 && i != 0)
                {
                    Points[t] = new System.Drawing.Point(Nums[i - 1], Nums[i]);
                    t++;
                }
            }
        }

        public string BaseText { get; }
        public int VertexCount { get; }
        public System.Drawing.Point[] Points { get; }

        public Image GetImage(int Scale, Brush Brush, Pen Pen)
        {
            int diffX = 0, diffY = 0;
            int maxX = 0, maxY = 0;
            for(int i = 0;Points.Length > i; i++)
            {
                Point point = Points[i];

                diffX = point.X < diffX ? point.X : diffX;
                diffY = point.Y < diffY ? point.Y : diffY;
                maxX = point.X > maxX ? point.X : maxX;
                maxY = point.Y > maxY ? point.Y : maxY;
            }

            Bitmap bmp = new Bitmap((maxX - diffX) * Scale, (maxY - diffY) * Scale);
            Graphics g = Graphics.FromImage(bmp);

            Point[] points = new Point[Points.Length + 1];
            Point last;

            int len = Points.Length;
            for (int i = 0; len > i; i++)
            {
                points[i] = new Point((Points[i].X - diffX) * Scale, (Points[i].Y - diffY) * Scale);
            }

            points[points.Length - 1] = points[0];

            g.FillPolygon(Brush, points);
            g.DrawLines(Pen, points);
            g.Dispose();

            return bmp;
        }
    }
}
