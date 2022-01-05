using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProject
{
    class OrderTimerEventArgs: EventArgs
    {
        public int OrderID { get; }
        public int TimeLeft { get; }
        public OrderTimerEventArgs(int id,int time)
        {
            OrderID = id;
            TimeLeft = time;
        }
    }
}
