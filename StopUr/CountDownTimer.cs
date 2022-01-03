using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StopUr
{
    public class CountDownTimer
    {
        private int countdownSeconds;
        private Thread thread;
        private bool run;
        private object _lock = new object();
        public event EventHandler CountDownChange;
        public int CountdownSeconds { get { return countdownSeconds;} }
        public CountDownTimer(int hour, int min, int sec)
        {
            this.countdownSeconds = ConvertToSec(hour, min, sec);
        }
        /// <summary>
        /// Converts to seconds for easier Calculations
        /// </summary>
        /// <param name="h"></param>
        /// <param name="m"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        private int ConvertToSec(int h, int m, int s)
        {
            int seconds = 0;
            seconds += (h * 3600);
            seconds += (m * 60);
            seconds += s;
            return seconds;
        }

        /// <summary>
        /// Converts to a string format to later use in override to string
        /// </summary>
        /// <returns></returns>
        private string ConvertToStringFormat()
        {
            int cs = countdownSeconds;
            int h, m, s;
            h = cs / 3600;
            m =  (cs / 60) % 60;
            s = cs % 60;
            return string.Format("{0} : {1} : {2}", h, m, s);
        }

        /// <summary>
        /// Creates a thread with countdown method then starts it
        /// </summary>
        public void StartTimer()
        {
            this.thread = new Thread(Countdown);
            this.thread.Start();
            run = true;
        }

        /// <summary>
        /// Sets run to false to stop timer
        /// </summary>
        public void StopTimer()
        {
            run = false;
        }

        /// <summary>
        /// Countdown if countdownSeconds is over zero and run is true, then post through event, and waits a sec
        /// </summary>
        public void Countdown()
        {
            lock (_lock)
            {
                while (this.countdownSeconds > 0 && this.run == true)
                {
                    this.countdownSeconds--;
                    OnCountChange(EventArgs.Empty);
                    Thread.Sleep(1000);
                }
                if (this.countdownSeconds == 0)
                {
                    PlaySound();
                }
            }
        }

        /// <summary>
        /// OnCountChange Invokes on event
        /// </summary>
        /// <param name="e"></param>
        private void OnCountChange(EventArgs e)
        {
            this.CountDownChange?.Invoke(this, e);
        }

        /// <summary>
        /// SoundPlayer for when Alarm Is finished
        /// </summary>
        private void PlaySound()
        {
            System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Users\MBour\OneDrive\Dokumenter\GitHub\WPFSkoleJan2022\StopUr\AlarmSound\Alarm.wav";
            soundPlayer.Load();
            soundPlayer.PlaySync();
        }
        /// <summary>
        /// overrides tostring
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ConvertToStringFormat();
        }
    }
}
