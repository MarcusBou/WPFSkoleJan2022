using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EventsProject
{
    class OrderTimer
    {
        private int orderID;
        private int timeLeft;
        private bool isGettingCreated;
        private Random rnd = new Random();

        public EventHandler<OrderTimerEventArgs> OrderTimerChanged;
        public OrderTimer()
        {
            timeLeft = rnd.Next(15, 46);
            isGettingCreated = true;
            Thread t = new Thread(Countdown);
            t.Start();
        }

        public void Countdown()
        {
            while (timeLeft > 0 && isGettingCreated == true)
            {
                timeLeft--;
                OrderTimerChanged?.Invoke(this, new OrderTimerEventArgs(orderID ,timeLeft));
                Thread.Sleep(500);
            }
        }
    }
}
