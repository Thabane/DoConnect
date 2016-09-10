using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DataClient;
using Newtonsoft.Json;
using ObjectModel.Infermedica_Models;

namespace DocConnectApp.Controllers
{
    public class DiagnosisExpertSystemController : ApiController
    {
        [HttpGet]
        [Route("api/DiagnosisExpertSystem/GetSymptoms")]
        public async Task<List<Symptom>> GetGetSymptoms()
        {
            Infermedica med = new Infermedica();
            string result = await med.GetSymptoms();
            var Symptoms = JsonConvert.DeserializeObject<List<Symptom>>(result)
?? new List<Symptom>();
            return Symptoms;
        }
    }
}
