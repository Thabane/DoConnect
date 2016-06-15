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
            BusinessLogic bl = new BusinessLogic();
            bl.CreateUser();
            Console.WriteLine("User Created.");
            Console.ReadKey();
        }
    }
}
