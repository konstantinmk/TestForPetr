using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Shapes;

namespace TestForPetr.Resources
{
    public partial class TestControlItem
    {
        private void EllipseB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse control = (Ellipse)sender;
            ContentControl contentControl = (ContentControl)control.Tag;
            if (contentControl != null)
            {
                Selector.SetIsSelected(contentControl, true);
            }
            e.Handled = true;
        }
    }
}
