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
    class Toilet : IControlElement
    {
        public Ellipse ellipse;
        public Rectangle rectangle;
        int rotationAngle = 0;
        public Toilet(double x, double y)
        {
            double width = 20;
            UserRectagle userRectagle = new UserRectagle(width, 10, x - width / 2, y, 1, Brushes.Black, Brushes.Transparent);
            rectangle = userRectagle.rectangle;

            UserElipse userElipse = new UserElipse(Brushes.Black, width, 25, x - width / 2, y + 10);
            ellipse = userElipse.ellipse;
        }
        public Toilet()
        { }
        public Toilet FindItem(double x, double y)
        {
            double x1, x2, y1, y2;
            if (rotationAngle == 90)
            {
                x1 = Canvas.GetLeft(ellipse);
                y1 = Canvas.GetTop(ellipse);
                x2 = x1 + ellipse.Width + rectangle.Width;
                y2 = y1 + ellipse.Height;
            }
            else if (rotationAngle == 180)
            {
                x1 = Canvas.GetLeft(ellipse);
                y1 = Canvas.GetTop(ellipse);
                x2 = x1 + ellipse.Width;
                y2 = y1 + ellipse.Height + rectangle.Height;
            }
            else if(rotationAngle == 270)
            {
                x1 = Canvas.GetLeft(rectangle);
                y1 = Canvas.GetTop(rectangle);
                x2 = x1 + rectangle.Width + ellipse.Width;
                y2 = y1 + rectangle.Height;
            }
            else
            {
                x1 = Canvas.GetLeft(rectangle);
                y1 = Canvas.GetTop(rectangle);
                x2 = rectangle.Width + x1;
                y2 = rectangle.Height + ellipse.Height + y1;
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
                if(rotationAngle == 90)
                {
                    userRectagle = new UserRectagle(ellipse.Width + rectangle.Width + 10, ellipse.Height + 10,
                                                        Canvas.GetLeft(ellipse) - 5, Canvas.GetTop(ellipse) - 5, 1);
                }
                else if(rotationAngle == 180)
                {
                    userRectagle = new UserRectagle(ellipse.Width + 10, ellipse.Height + rectangle.Width,
                                                        Canvas.GetLeft(ellipse) - 5, Canvas.GetTop(ellipse) - 5, 1);
                }
                else if(rotationAngle == 270)
                {
                    userRectagle = new UserRectagle(ellipse.Width + rectangle.Width + 10, rectangle.Height +10,
                                                        Canvas.GetLeft(rectangle) - 5, Canvas.GetTop(rectangle) - 5, 1);
                }
                else
                {
                    userRectagle = new UserRectagle(rectangle.Width + 10, rectangle.Width + ellipse.Height,
                                                       Canvas.GetLeft(rectangle) - 5, Canvas.GetTop(rectangle) - 5, 1);
                }
                     
                return userRectagle.rectangle;
            }
            else return null;
        }
        public Toilet Rotate()
        {
            double x = Canvas.GetLeft(rectangle) + rectangle.Width;
            double y = Canvas.GetTop(rectangle) + rectangle.Height ;
            UserRectagle userRectagle = new UserRectagle(rectangle.Height, rectangle.Width, 0, 0, 1, Brushes.Black, Brushes.Transparent);
            rectangle = userRectagle.rectangle;
            if (rotationAngle == 0)
            {
                rotationAngle = 90;
                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y);

                x = Canvas.GetLeft(rectangle) - ellipse.Height;
                y = Canvas.GetTop(rectangle);
                UserElipse userElipse = new UserElipse(Brushes.Black, ellipse.Height, ellipse.Width, x, y);
                ellipse = userElipse.ellipse;
            }
            else if(rotationAngle == 90)
            {
                rotationAngle = 180;
                Canvas.SetLeft(rectangle, x - rectangle.Width - rectangle.Width/2);
                Canvas.SetTop(rectangle, y);

                x = Canvas.GetLeft(rectangle);
                y = Canvas.GetTop(rectangle) - ellipse.Width;
                UserElipse userElipse = new UserElipse(Brushes.Black, ellipse.Height, ellipse.Width, x, y);
                ellipse = userElipse.ellipse;
            }
            else if(rotationAngle == 180)
            {
                rotationAngle = 270;
                Canvas.SetLeft(rectangle, x - 2 * rectangle.Width);
                Canvas.SetTop(rectangle, y - rectangle.Height - rectangle.Width);

                x = Canvas.GetLeft(rectangle) + rectangle.Width;
                y = Canvas.GetTop(rectangle);
                UserElipse userElipse = new UserElipse(Brushes.Black, ellipse.Height, ellipse.Width, x, y);
                ellipse = userElipse.ellipse;
            }
            else 
            {
                rotationAngle = 0;
                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y - 2 * rectangle.Width);

                x = Canvas.GetLeft(rectangle);
                y = Canvas.GetTop(rectangle) + rectangle.Height;
                UserElipse userElipse = new UserElipse(Brushes.Black, ellipse.Height, ellipse.Width, x, y);
                ellipse = userElipse.ellipse;
            }

            return this;
        }
        public void Move(double x, double y)
        {
            if (rotationAngle == 90)
            {
                Canvas.SetLeft(ellipse, x);
                Canvas.SetTop(ellipse, y);

                Canvas.SetLeft(rectangle, x+ ellipse.Width);
                Canvas.SetTop(rectangle, y);
            }
            else if (rotationAngle == 180)
            {
                Canvas.SetLeft(ellipse, x);
                Canvas.SetTop(ellipse, y);

                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y + ellipse.Height);
            }
            else if (rotationAngle == 270)
            {
                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y);

                Canvas.SetLeft(ellipse, x + rectangle.Width);
                Canvas.SetTop(ellipse, y);
            }
            else
            {
                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y);

                Canvas.SetLeft(ellipse, x);
                Canvas.SetTop(ellipse, y + rectangle.Height);
            }
        }
    }
}
