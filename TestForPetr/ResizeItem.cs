using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TestForPetr
{
    public class ResizeItem : Thumb
    {
        public ResizeItem()
        {
            DragDelta += new DragDeltaEventHandler(this.ResizeThumb_DragDelta);
        }

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (DataContext is ContentControl TestControlItem)
            {
                double deltaVertical, deltaHorizontal;
                Label label = (Label)TestControlItem.Content;
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Bottom:
                        deltaVertical = Math.Min(-e.VerticalChange, TestControlItem.ActualHeight - TestControlItem.MinHeight);
                        TestControlItem.Height -= deltaVertical;                        
                        MainWindow.last_height = TestControlItem.Height;
                        label.FontSize = TestControlItem.Height / 3;
                        break;
                    case VerticalAlignment.Top:
                        deltaVertical = Math.Min(e.VerticalChange, TestControlItem.ActualHeight - TestControlItem.MinHeight);
                        Canvas.SetTop(TestControlItem, Canvas.GetTop(TestControlItem) + deltaVertical);
                        TestControlItem.Height -= deltaVertical;
                        MainWindow.last_height = TestControlItem.Height;
                        label.FontSize = TestControlItem.Height / 3;
                        break;
                    default:
                        break;
                }

                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        deltaHorizontal = Math.Min(e.HorizontalChange, TestControlItem.ActualWidth - TestControlItem.MinWidth);
                        Canvas.SetLeft(TestControlItem, Canvas.GetLeft(TestControlItem) + deltaHorizontal);
                        TestControlItem.Width -= deltaHorizontal;
                        MainWindow.last_width = TestControlItem.Width;
                        break;
                    case HorizontalAlignment.Right:
                        deltaHorizontal = Math.Min(-e.HorizontalChange, TestControlItem.ActualWidth - TestControlItem.MinWidth);
                        TestControlItem.Width -= deltaHorizontal;
                        MainWindow.last_width = TestControlItem.Width;
                        break;
                    default:
                        break;
                }
            }

            e.Handled = true;
        }
    }
}
