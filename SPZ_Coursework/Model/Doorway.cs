using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace WPFWork.Model
{

    class Doorway : IControlElement
    {
        public Rectangle rectangle;
        public Line line2, line3, line4;
        int rotationAngle = 0;
        public Doorway(double width, double x, double y)
        {
            UserRectagle userRectagle = new UserRectagle(width, 10, x, y, 0, Brushes.Transparent, Brushes.White);
            rectangle = userRectagle.rectangle;
            UserLine line = new UserLine(0, rectangle.Height, Canvas.GetLeft(rectangle), Canvas.GetTop(rectangle), 2);
            line2 = line.line;
            line = new UserLine(0, 2 * rectangle.Height, Canvas.GetLeft(rectangle) + rectangle.Width / 2, Canvas.GetTop(rectangle) - 5, 2);
            line3 = line.line;
            line = new UserLine(0, rectangle.Height, Canvas.GetLeft(rectangle) + rectangle.Width, Canvas.GetTop(rectangle), 2);
            line4 = line.line;
        }
        public Doorway()
        { }
        public Line this[int index]
        {
            get
            {
                switch(index)
                {
                    case 0: return line2;
                    case 1: return line3;
                    case 2: return line4;
                    default: return null;
                }
            }
        }
        public Doorway FindItem(double x, double y)
        {
            double x1, x2, y1, y2;
            if (rotationAngle == 0)
            {
                 x1 = Canvas.GetLeft(rectangle);
                 y1 = Canvas.GetTop(rectangle);
                 x2 = x1 + rectangle.Width;
                 y2 = y1 + rectangle.Height;
            }
            else
            {
                x1 = Canvas.GetLeft(line3);
                y1 = Canvas.GetTop(rectangle);
                x2 = x1 + 2 * rectangle.Width;
                y2 = y1 + rectangle.Height;
            }
            
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
                UserRectagle userRectagle;
                if(rotationAngle == 0)
                { 
                    double x1 = Canvas.GetLeft(rectangle);
                    double y1 = Canvas.GetTop(line3);
 
                     userRectagle = new UserRectagle(rectangle.Width + 10, 2 * rectangle.Height + 10, x1 - 5, y1 - 5, 1);
                }
                else
                {
                    double x1 = Canvas.GetLeft(line3);
                    double y1 = Canvas.GetTop(rectangle);

                    userRectagle = new UserRectagle(2 * rectangle.Width + 10, rectangle.Height + 10, x1 - 5, y1 - 5, 1);
                }
               
                return userRectagle.rectangle;
            }
            else return null;
        }

        public Doorway Rotate()
        {
            double x = Canvas.GetLeft(rectangle) + rectangle.Width / 2 - rectangle.Height / 2;
            double y = Canvas.GetTop(rectangle) - rectangle.Width / 2 + rectangle.Height / 2;

            UserRectagle userRectagle = new UserRectagle(rectangle.Height, rectangle.Width, 0, 0, 0, Brushes.Transparent, Brushes.White);
            rectangle = userRectagle.rectangle;
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
            if (rotationAngle == 0)
            {
                rotationAngle = 90;
                UserLine userLine = new UserLine(rectangle.Width, 0, Canvas.GetLeft(rectangle), Canvas.GetTop(rectangle), 2);
                line2 = userLine.line;

                userLine = new UserLine(2 * rectangle.Width, 0, Canvas.GetLeft(rectangle) - 5, Canvas.GetTop(rectangle) + rectangle.Height / 2, 2);
                line3 = userLine.line;

                userLine = new UserLine(rectangle.Width, 0, Canvas.GetLeft(rectangle), Canvas.GetTop(rectangle) + rectangle.Height, 2);
                line4 = userLine.line;
            }
            else
            {
                rotationAngle = 0;
                UserLine userLine = new UserLine(0, rectangle.Height, Canvas.GetLeft(rectangle), Canvas.GetTop(rectangle), 2);
                line2 = userLine.line;

                userLine = new UserLine(0, 2 * rectangle.Height, Canvas.GetLeft(rectangle) + rectangle.Width / 2, Canvas.GetTop(rectangle) - 5, 2);
                line3 = userLine.line;

                userLine = new UserLine(0, rectangle.Height, Canvas.GetLeft(rectangle) + rectangle.Width, Canvas.GetTop(rectangle), 2);
                line4 = userLine.line;
            }

            return this;
        }
        public void Move(double x, double y)
        {
            if (rotationAngle == 0)
            {
                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y + 5);

                Canvas.SetLeft(line2, x);
                Canvas.SetTop(line2, y + 5);

                Canvas.SetLeft(line3, x + rectangle.Width/2);
                Canvas.SetTop(line3, y);

                Canvas.SetLeft(line4, x + rectangle.Width);
                Canvas.SetTop(line4, y+5);

            }
            else
            {
                Canvas.SetLeft(rectangle, x + 5);
                Canvas.SetTop(rectangle, y);

                Canvas.SetLeft(line2, x + 5);
                Canvas.SetTop(line2, y);

                Canvas.SetLeft(line3, x);
                Canvas.SetTop(line3, y + rectangle.Height / 2);

                Canvas.SetLeft(line4, x + 5);
                Canvas.SetTop(line4, y + rectangle.Height);
            }
        }
    }
}
