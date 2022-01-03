using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace WPFWork.Model
{
    interface IControlElement
    {
        Rectangle Highlight(double x, double y);
        void Move(double x, double y);
    }
}
