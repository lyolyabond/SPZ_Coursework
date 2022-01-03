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
    class UWindow : IControlElement
    {
        public Rectangle rectangle;
        public Line line1, line2;
        int rotationAngle = 0;
        public UWindow(double width, double x, double y)
        {
            UserRectagle userRectagle = new UserRectagle(width, 10, x - width / 2, y, 1, Brushes.Black, Brushes.White);
            rectangle = userRectagle.rectangle;
            UserLine userLine = new UserLine(width, 0, Canvas.GetLeft(rectangle), Canvas.GetTop(rectangle) + 3, 1);
            line1 = userLine.line;
            userLine = new UserLine(width, 0, Canvas.GetLeft(rectangle), Canvas.GetTop(rectangle) + rectangle.Height - 3, 1);
            line2 = userLine.line;
        }
        public UWindow()
        { }

        public UWindow FindItem(double x, double y)
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
                double x1 = Canvas.GetLeft(rectangle);
                double y1 = Canvas.GetTop(rectangle);
                UserRectagle userRectagle = new UserRectagle(rectangle.Width + 10, rectangle.Height + 10, x1 - 5, y1 - 5, 1);
                return userRectagle.rectangle;
            }
            else return null;
        }
        public UWindow Rotate()
        {
            double x = Canvas.GetLeft(rectangle) + rectangle.Width / 2 - rectangle.Height / 2;
            double y = Canvas.GetTop(rectangle) - rectangle.Width / 2 + rectangle.Height / 2;

            UserRectagle userRectagle = new UserRectagle(rectangle.Height, rectangle.Width, 0, 0, 1, Brushes.Black, Brushes.White);
            rectangle = userRectagle.rectangle;
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
            if(rotationAngle == 0)
            {
                rotationAngle = 90;
                UserLine userLine = new UserLine(0, rectangle.Height, Canvas.GetLeft(rectangle) + 3, Canvas.GetTop(rectangle), 1);
                line1 = userLine.line;
                userLine = new UserLine(0, rectangle.Height, Canvas.GetLeft(rectangle) + rectangle.Width - 3, Canvas.GetTop(rectangle), 1);
                line2 = userLine.line;
            }
            else
            {
                rotationAngle = 0;
                UserLine userLine = new UserLine(rectangle.Width, 0, Canvas.GetLeft(rectangle), Canvas.GetTop(rectangle) + 3, 1);
                line1 = userLine.line;
                userLine = new UserLine(rectangle.Width, 0, Canvas.GetLeft(rectangle), Canvas.GetTop(rectangle) + rectangle.Height - 3, 1);
                line2 = userLine.line;
            }
            
            return this;
        }

        public void Move(double x, double y)
        {
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
            if (rotationAngle == 90)
            {
                Canvas.SetLeft(line1, x + 3);
                Canvas.SetTop(line1, y);

                Canvas.SetLeft(line2, x + rectangle.Width - 3);
                Canvas.SetTop(line2, y);

            }
            else
            {
                Canvas.SetLeft(line1, x);
                Canvas.SetTop(line1, y + 3);

                Canvas.SetLeft(line2, x);
                Canvas.SetTop(line2, y + rectangle.Height - 3);
            }
        }
    }
}
