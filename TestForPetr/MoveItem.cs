using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TestForPetr
{
    public class MoveItem : Thumb
    {
        public MoveItem()
        {
            DragDelta += new DragDeltaEventHandler(this.MoveItem_DragDelta);
        }

        private void MoveItem_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (this.DataContext is ContentControl TestControlItem)
            {
                double left = Canvas.GetLeft(TestControlItem);
                double top = Canvas.GetTop(TestControlItem);

                Canvas.SetLeft(TestControlItem, left + e.HorizontalChange);
                Canvas.SetTop(TestControlItem, top + e.VerticalChange);
            }
        }
    }
}