using System;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace WPFWork.Model
{
    public class Wall 
    {
        public Line line { get; set; }
        public Wall(Brush brush, double x1, double y1, double x2, double y2)
        {
            UserLine userLine = new UserLine(brush, x1, y1, x2, y2);
            line = userLine.line;
        }
        public Wall()
        { }
        public void Move(double x, double y)
        {
            Canvas.SetLeft(line, x);
            Canvas.SetTop(line, y);
        }
        public Wall FindItem(double x, double y)
        {
            double X1,X2, Y1, Y2;
            double x1 = line.X1;
            double y1 = line.Y1;
            double x2 = line.X2;
            double y2 = line.Y2;
            if(x2 > x1)
            {
                X1 = x1;
                X2 = x2;
            }
            else
            {
                X1 = x2;
                X2 = x1;
            }
            if(y2 > y1)
            {
                Y1 = y1;
                Y2 = y2;
            }
            else
            {
                Y1 = y2;
                Y2 = y1;
            }
            if (Math.Abs(Y1 - Y2) > Math.Abs(X1 - X2))
            {
                if (x < X2 + 10 && x > X1 && y < Y2 && y > Y1)
                {
                    return this;
                }
            }
            else
            {
                if (x < X2 && x > X1 && y < Y2 && y > Y1-10)
                {
                    return this;
                }
            }
           
            return null;
        }
        public void Highlight(double x, double y, ref Ellipse ellipse1, ref Ellipse ellipse2)
        {
            if (FindItem(x, y) != null)
            {
                UserElipse userElipse = new UserElipse(Brushes.Black, Brushes.Transparent, 12, 12, line.X1 - 5, line.Y1 - 5);
                ellipse1 = userElipse.ellipse;
                userElipse = new UserElipse(Brushes.Black, Brushes.Transparent, 12, 12, line.X2 - 7, line.Y2 - 5);
                ellipse2 = userElipse.ellipse;
            }

        }
    }
}
