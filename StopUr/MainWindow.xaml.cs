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

namespace StopUr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CountDownTimer timer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void kage(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() => Showtimer.Content = timer.ToString());
        }
        private void createTimer_Click(object sender, RoutedEventArgs e)
        {
            timer = new CountDownTimer((int)hours.Value, (int)minutes.Value, (int)seconds.Value);
            hours.Value = 0;
            minutes.Value = 0;
            seconds.Value 0;
            timer.CountDownChange += kage;
        }
        private void startTimer_Click(object sender, RoutedEventArgs e)
        {
            timer.StartTimer();
        }
        private void stopTimer_Click(object sender, RoutedEventArgs e)
        {
            timer.StopTimer();
        }

        
    }
}
