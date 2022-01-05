using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace EventsProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderTimer orderTimer = new OrderTimer();
            Label label = new Label();
            label.Content = "Helloe";
            Stack.Children.Add(label);
            orderTimer.OrderTimerChanged += OtChanged;
        }

        private void OtChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                Debug.WriteLine("OT Update");
                time.Content = ((OrderTimerEventArgs)e).TimeLeft;

          });
        }
    }
}
