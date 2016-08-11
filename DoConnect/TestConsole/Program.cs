using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClient;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataLayer bl = new DataLayer();
            bl.CreateUser(1);
            Console.WriteLine("User Created.");
            Console.ReadKey();
        }
    }
}
