using System;
using System.Threading;

namespace ReadVisor.Agent
{
    public class Controller
    {
        private Painter painter;
        private bool abort;

        public Controller(double interval)
        {
            painter = new Painter();

            Interval = interval;
        }

        public double Interval { get; }

        public void Execute()
        {
            //while (Wait(seconds: Interval))
            //    painter.PrintScreen();

            for (int i = 0; i < 500; i++)
            {
                Wait(Interval);
                painter.PrintScreen();
            }
        }

        public void Stop()
        {
            abort = false;
        }

        private bool Wait(double seconds)
        {
            if (abort) 
                return false;

            Thread.Sleep((int)seconds * 1000);

            return true;
        }
    }
}
