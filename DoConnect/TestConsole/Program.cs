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
            DataLayer dataLayer = new DataLayer();

            var hold = dataLayer.GetAllPatients();


            //dataLayer.CreateConsultation(1, 1, DateTime.Now, "reason for consultation", "symptoms", "clinicalfindings", "diagnosis", "testresultsummary", "treatmentplan", 1, 1);
            //dataLayer.GetConsultation(1);
            //dataLayer.GetAllConsultations();
            //dataLayer.NewUpdateConsultation(1,1, 1, DateTime.Now, "reason for consultation", "symptoms", "clinicalfindings", "diagnosis", "testresultsummary", "treatmentplan", 1, 1);

            //dataLayer.

            //Console.WriteLine("Users Created");
            Console.ReadKey();
        }
    }
}
