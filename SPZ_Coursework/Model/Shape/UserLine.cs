using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace WPFWork.Model
{
    class UserLine
    {
        public Line line { get; set; }
        public UserLine(Brush brush, double x2, double y2, double offX, double offY, double strokeThickness)
        {
            CreateLine(brush, 0, 0, x2, y2, strokeThickness);
            Canvas.SetLeft(line, offX);
            Canvas.SetTop(line, offY);
        }
        public UserLine(double x2, double y2, double offX, double offY, double strokeThickness)
        {
            CreateLine(Brushes.Black, 0, 0, x2, y2, strokeThickness);
            Canvas.SetLeft(line, offX);
            Canvas.SetTop(line, offY);
        }
        public UserLine(Brush brush, double x1, double y1, double x2, double y2)
        {
            CreateLine(brush, x1, y1, x2, y2, 10);
        }
        void CreateLine(Brush brush, double x1, double y1, double x2, double y2, double strokeThickness)
        {
            line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.StrokeThickness = strokeThickness;
            line.Stroke = brush;
        }
    }
}
