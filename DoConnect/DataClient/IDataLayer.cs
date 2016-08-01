using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel;

namespace DataClient
{
    public interface IDataLayer
    {
        int CreateUser();
        bool NewUpdateDoctor(Doctor doc, int UserId);
        Doctor GetDoctor(int DocID);
        List<Patient> GetAllPatients();
    }
}
