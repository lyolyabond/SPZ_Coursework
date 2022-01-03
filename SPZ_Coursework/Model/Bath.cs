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
    [KnownType(typeof(Ellipse))]
    [KnownType(typeof(Line))]
    class Bath : IControlElement
    {
        [DataMember]
        public Ellipse ellipse;
        [DataMember]
        public Line line1, line2;
        [DataMember]
        int rotationAngle = 0;
        public Bath(double x, double y)
        {
            UserElipse userElipse = new UserElipse(Brushes.Black, 24, 50, x - 24 / 2, y);
            ellipse = userElipse.ellipse;
            UserLine userLine = new UserLine(0, ellipse.Height / 6, x, y, 1);
            line1 = userLine.line;
            userLine = new UserLine(8, 0, x-4, y + ellipse.Height / 6, 1);
            line2 = userLine.line;
        }

        public Bath FindItem(double x, double y)
        {
            double x1 = Canvas.GetLeft(ellipse);
            double y1 = Canvas.GetTop(ellipse);
            double x2 = ellipse.Width + x1;
            double y2 = ellipse.Height + y1;
            if (x < x2 && x > x1 && y < y2 && y > y1)
            {
                return this;
            }
            return null;
        }
        public Bath()
        {
        }
        public Rectangle Highlight(double x, double y)
        {
            double x1 = Canvas.GetLeft(ellipse);
            double y1 = Canvas.GetTop(ellipse);
            if (FindItem(x, y) != null)
            {
                UserRectagle userRectagle = new UserRectagle(ellipse.Width + 10, ellipse.Height + 10, x1 - 5, y1 - 5, 1);
                return userRectagle.rectangle;
            }
            else return null;
        }
       public Bath Rotate()
        {
            double x = Canvas.GetLeft(ellipse) + ellipse.Width / 2 - ellipse.Height / 2;
            double y = Canvas.GetTop(ellipse) - ellipse.Width / 2 + ellipse.Height / 2;
            UserElipse userElipse = new UserElipse(Brushes.Black, ellipse.Height, ellipse.Width, x, y);
            ellipse = userElipse.ellipse;
            double widthLine1 = ellipse.Width / 6;
            double  hightLine1 = ellipse.Height / 6;

            if (rotationAngle == 0)
            {
                rotationAngle = 90;
                UserLine userLine = new UserLine( widthLine1, 0, x + ellipse.Width - widthLine1, y + ellipse.Height / 2, 1);
                line1 = userLine.line;
                userLine = new UserLine( 0, 8, x + ellipse.Width - widthLine1, y + ellipse.Height / 2 - 4, 1);
                line2 = userLine.line;

            }
            else if (rotationAngle == 90)
            {
                rotationAngle = 180;
                UserLine userLine = new UserLine( 0, hightLine1, x + ellipse.Width / 2, y + ellipse.Height - hightLine1, 1);
                line1 = userLine.line;
                userLine = new UserLine( 8, 0, x + ellipse.Width / 2 - 4, y + ellipse.Height - hightLine1, 1);
                line2 = userLine.line;
            }
            else if (rotationAngle == 180)
            {
                rotationAngle = 270;
                UserLine userLine = new UserLine(widthLine1, 0, x, y + ellipse.Height / 2, 1);
                line1 = userLine.line;
                userLine = new UserLine( 0, 8, x + widthLine1, y + ellipse.Height / 2 - 4, 1);
                line2 = userLine.line;
            }
            else
            {
                rotationAngle = 0;
                UserLine userLine = new UserLine(0, hightLine1, x + ellipse.Width / 2, y, 1);
                line1 = userLine.line;
                userLine = new UserLine( 8, 0, x + ellipse.Width / 2 - 4, y + hightLine1, 1);
                line2 = userLine.line;
            }
            return this;
        }
        public void Move(double x, double y)
        {
            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
            if (rotationAngle == 0)
            {
            Canvas.SetLeft(line1, x + ellipse.Width / 2);
            Canvas.SetTop(line1, y);

            Canvas.SetLeft(line2, x + ellipse.Width / 2 - 4);
            Canvas.SetTop(line2, y + ellipse.Height / 6);
            }
            else if (rotationAngle == 90)
            {
                Canvas.SetLeft(line1, x + ellipse.Width - ellipse.Height / 6 - 5);
                Canvas.SetTop(line1, y + ellipse.Height / 2);

                Canvas.SetLeft(line2, x + ellipse.Width - ellipse.Height / 6 - 5);
                Canvas.SetTop(line2, y + ellipse.Height / 2 - 4);
            }
            else if (rotationAngle == 180)
            {
                Canvas.SetLeft(line1, x + ellipse.Width / 2);
                Canvas.SetTop(line1, y + ellipse.Height - ellipse.Height / 6);

                Canvas.SetLeft(line2, x + ellipse.Width / 2 - 4);
                Canvas.SetTop(line2, y + ellipse.Height - ellipse.Width / 6 - 5);
            }
            else if (rotationAngle == 270)
            {
                Canvas.SetLeft(line1, x);
                Canvas.SetTop(line1, y + ellipse.Height / 2);

                Canvas.SetLeft(line2, x + ellipse.Width / 6);
                Canvas.SetTop(line2, y + ellipse.Height / 2 - 4);
            }
            else
            {
                Canvas.SetLeft(line1, x + ellipse.Width / 2);
                Canvas.SetTop(line1, y);

                Canvas.SetLeft(line2, x + ellipse.Width / 2 - 4);
                Canvas.SetTop(line2, y + ellipse.Height / 2);
            }


        }
    }
}
