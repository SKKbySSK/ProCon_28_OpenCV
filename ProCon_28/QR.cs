using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCon_28
{
    class QR
    {
        public QR(string ShapeData)
        {
            RawShapeData = ShapeData;

            bool _count = false;
            int ind = 0;

            string str = "";
            for(int i = 0;ShapeData.Length > i; i++)
            {
                char c = ShapeData[i];

                if (c == ':')
                {
                    if (!_count)
                    {
                        _count = true;
                        Count = int.Parse(str);
                        Shapes = new Shape[Count];
                    }
                    else
                    {
                        Shapes[ind] = new Shape(str);
                        ind++;
                    }

                    str = "";
                }
                else
                    str += c;
            }

            if(ind == Count - 1)
            {
                Shapes[ind++] = new Shape(str);
                IsFrameAvailable = false;
            }
            else
            {
                Frame = new Shape(str);
                IsFrameAvailable = true;
            }
        }

        public Shape[] Shapes { get; }
        public string RawShapeData { get; }
        public int Count { get; }

        public bool IsFrameAvailable { get; } = false;
        public Shape Frame { get; }
    }
}
