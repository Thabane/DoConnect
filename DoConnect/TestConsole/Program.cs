using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClient;
using ObjectModel;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataLayer bl = new DataLayer();
            DoctorProfile doc = bl.GetDoctor(3);
            Console.ReadKey();
        }
    }
}
