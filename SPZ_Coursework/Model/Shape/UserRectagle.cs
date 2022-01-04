using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace WPFWork.Model
{
    class UserRectagle
    {
        public Rectangle rectangle;
        public UserRectagle(double width, double hight, double x, double y, double strokeThickness)
        {
            CreateRectangle(width, hight, Brushes.Black, strokeThickness);
            rectangle.StrokeDashArray = new DoubleCollection() { 2 };
            rectangle.Margin = new Thickness(x, y, 0, 0);
        }
        public UserRectagle(double width, double hight, double x, double y, double strokeThickness, Brush brushS, Brush brushF)
        {
            CreateRectangle(width, hight, brushS, strokeThickness);
            rectangle.Fill = brushF;
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
        }
 
        void CreateRectangle(double width, double hight, Brush brushS, double strokeThickness)
        {
            rectangle = new Rectangle();
            rectangle.Width = width;
            rectangle.Height = hight;
            rectangle.Stroke = brushS;
            rectangle.StrokeThickness = strokeThickness;
        }
    }
}
