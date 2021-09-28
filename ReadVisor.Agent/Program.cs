using System;

namespace ReadVisor.Agent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var controller = new Controller(interval: 0.2);

            controller.Execute();
        }
    }
}
