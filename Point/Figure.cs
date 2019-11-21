using System;
using System.Collections.Generic;
using System.Text;

namespace Point
{
    class Figure
    {
        protected List<MyPoint> pointList = new List<MyPoint>();
        public void DrawFigure()
        {
            foreach(MyPoint point in pointList)
            {
                point.Draw();
            }
        }
    }

    
}
