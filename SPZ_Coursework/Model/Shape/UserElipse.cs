using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace WPFWork.Model
{
    class UserElipse
    {
        public Ellipse ellipse { get; set; }
        public UserElipse(SolidColorBrush brush, SolidColorBrush brushFill, double width, double height)
        {
            CreateEllipse(brush, width, height);
            ellipse.Fill = brushFill;
        }
        public UserElipse(SolidColorBrush brush, SolidColorBrush brushFill, double width, double height, double x, double y)
        {
            CreateEllipse(brush, width, height);
            ellipse.Fill = brushFill;
            ellipse.StrokeDashArray = new DoubleCollection() { 1 };
            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
        }
        public UserElipse(SolidColorBrush brush, double width, double height, double x, double y)
        {
            CreateEllipse(brush, width, height);
            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
        }
        void CreateEllipse(SolidColorBrush brush, double width, double height)
        {
            ellipse = new Ellipse();
            ellipse.Stroke = brush;
            ellipse.Width = width;
            ellipse.Height = height;
        }

    }
}
