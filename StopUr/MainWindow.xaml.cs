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

        /// <summary>
        /// Writes To label when Event has happened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteToLabel(object sender, EventArgs e)
        {
            try
            {
                Dispatcher.Invoke(() => Showtimer.Content = timer.ToString());
            }
            finally
            {

            }
        }

        /// <summary>
        /// Creates Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createTimer_Click(object sender, RoutedEventArgs e)
        {
            timer = new CountDownTimer((int)hours.Value, (int)minutes.Value, (int)seconds.Value);
            hours.Value = 0;
            minutes.Value = 0;
            seconds.Value = 0;
            Showtimer.Content = timer.ToString();
            timer.CountDownChange += WriteToLabel;
        }
        /// <summary>
        /// starts Timer if exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startTimer_Click(object sender, RoutedEventArgs e)
        {
            if (timer != null)
            {
                timer.StartTimer();
            }
        }
        /// <summary>
        /// Stops timer if it exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopTimer_Click(object sender, RoutedEventArgs e)
        {
            if (timer != null)
            {
                timer.StopTimer();
            }
        }

        /// <summary>
        /// shutdowns thread and stopwatch on windowClose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (timer != null)
            {
                timer.StopTimer();
            }
        }
    }
}
