using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestForPetr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double last_height = 100.0d;
        public static double last_width = 100.0d;        
        private int count_item = 1;
        private List<ContentControl> items = new List<ContentControl> ();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool rez=false;
            foreach (ContentControl item in items)
            {
                if (Selector.GetIsSelected(item))
                {
                    Selector.SetIsSelected(item, false);
                    rez = true;
                }
                
            }
            if (rez) return;

            Canvas canvas = (Canvas)sender;
            Point p = e.GetPosition(canvas);            
            Style? style = FindResource("TestItemStyle") as Style;
            ContentControl TestControlItem = new()
            {
                Style = style,
                Width = last_width,
                Height = last_height

            };
            Canvas.SetLeft(TestControlItem, p.X);
            Canvas.SetTop(TestControlItem, p.Y);
            Label label = new() { 
                Content = count_item.ToString() , 
                VerticalAlignment= VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                IsHitTestVisible=false
            };
            label.FontSize = TestControlItem.Height / 3;
            TestControlItem.Content = label;
            Selector.SetIsSelected(TestControlItem, true);
            canvas.Children.Add(TestControlItem);
            items.Add(TestControlItem);
            count_item++;
        }
    }
}
