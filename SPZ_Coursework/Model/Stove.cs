using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization;

namespace WPFWork.Model
{
    [DataContract]
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Ellipse))]
    class Stove : IControlElement
    {
        [DataMember]
        public Rectangle rectangle;
        [DataMember]
        public Ellipse ellipse1, ellipse2, ellipse3, ellipse4;
        double offset1, offset2;
        public Stove(double x, double y)
        {
            double length = 30;
            UserRectagle userRectagle = new UserRectagle(length, length, x - length / 2, y, 1, Brushes.Black, Brushes.Transparent);
            rectangle = userRectagle.rectangle;
  
            offset1 = 3;
            offset2 = 3 + 4 + length/3;
            ellipse1 = CreateElipse(offset1, offset1, length);
            ellipse2 = CreateElipse(offset2, offset1, length);
            ellipse3 = CreateElipse(offset1, offset2, length);
            ellipse4 = CreateElipse(offset2, offset2, length);
        }
        public Stove()
        { }
        public Ellipse this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return ellipse1;
                    case 1: return ellipse2;
                    case 2: return ellipse3;
                    case 3: return ellipse4;
                    default: return null;
                }
            }
        }
        Ellipse CreateElipse(double offsetX, double offsetY, double length)
        {
            double x = Canvas.GetLeft(rectangle);
            double y = Canvas.GetTop(rectangle);
            UserElipse userElipse = new UserElipse(Brushes.Black, length / 3, length / 3, x + offsetX, y + offsetY);
            Ellipse ellipse = userElipse.ellipse;
            return ellipse;
        }
        public Stove FindItem(double x, double y)
        {
            double x1 = Canvas.GetLeft(rectangle);
            double y1 = Canvas.GetTop(rectangle);
            double x2 = rectangle.Width + x1;
            double y2 = rectangle.Height + y1;
            if (x < x2 && x > x1 && y < y2 && y > y1)
            {
                return this;
            }
            return null;
        }
        public Rectangle Highlight(double x, double y)
        {
            if (FindItem(x, y) != null)
            {
                UserRectagle userRectagle = new UserRectagle(rectangle.Width + 10, rectangle.Width + 10, Canvas.GetLeft(rectangle) - 5, Canvas.GetTop(rectangle) - 5, 1);
                return userRectagle.rectangle;
            }
            else return null;  
        }
        public void Move(double x, double y)
        {
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);

            Canvas.SetLeft(ellipse1, x + offset1);
            Canvas.SetTop(ellipse1, y + offset1);

            Canvas.SetLeft(ellipse2, x + offset2);
            Canvas.SetTop(ellipse2, y + offset1);

            Canvas.SetLeft(ellipse3, x + offset1);
            Canvas.SetTop(ellipse3, y + offset2);

            Canvas.SetLeft(ellipse4, x + offset2);
            Canvas.SetTop(ellipse4, y + offset2);
        }
    }
}
