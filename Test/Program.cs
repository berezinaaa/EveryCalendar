using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IEventNotifier notifier = new SmsNotifier();
            notifier.Notify();
            Console.ReadLine();
        }
    }
}
