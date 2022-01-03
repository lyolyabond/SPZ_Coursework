using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Runtime.Serialization;

namespace WPFWork.Model
{
    [DataContract]
    [KnownType(typeof(Rectangle))]
    class Door : IControlElement
    {
        [DataMember]
        public Rectangle rectangle { get; set; }
        public Door(double width, double x, double y)
        {
            UserRectagle userRectagle = new UserRectagle(width, 10, x - width / 2, y, 1,Brushes.Black, Brushes.Black);
            rectangle = userRectagle.rectangle;
        }
        public Door()
        {
        }
        public Door FindItem(double x, double y)
        {
            double x1 = Canvas.GetLeft(rectangle);
            double y1 = Canvas.GetTop(rectangle);
            double x2 = rectangle.Width + x1 ;
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
                double x1 = Canvas.GetLeft(rectangle);
                double y1 = Canvas.GetTop(rectangle);
                UserRectagle userRectagle = new UserRectagle(rectangle.Width + 10, rectangle.Height + 10, x1 - 5, y1 - 5, 1);
                return userRectagle.rectangle;
            }
            else return null;
        }
        public Door Rotate()
        {
            double x = Canvas.GetLeft(rectangle) + rectangle.Width / 2 - rectangle.Height / 2;
            double y = Canvas.GetTop(rectangle) - rectangle.Width / 2 + rectangle.Height / 2;

            UserRectagle userRectagle = new UserRectagle(rectangle.Height, rectangle.Width, 0, 0, 1, Brushes.Black, Brushes.Black);
            rectangle = userRectagle.rectangle;
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
            return this;
        }
        public void Move(double x, double y)
        {
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
        }
        
    }
}
