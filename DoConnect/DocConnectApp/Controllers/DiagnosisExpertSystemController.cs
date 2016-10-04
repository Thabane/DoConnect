using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
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
        [Route("api/DiagnosisExpertSystem/GetFiveRandomSymptoms")]
        public async Task<List<Symptom>> GetFiveRandomSymptoms()
        {
            Infermedica med = new Infermedica();
            string result = await med.GetSymptoms();
            var Symptoms = JsonConvert.DeserializeObject<List<Symptom>>(result)
?? new List<Symptom>();

            List<Symptom> sympt = new List<Symptom>();
            for (int i = 0; i < 5; i++)
            {
                sympt.Add(GetSymptom(Symptoms));
            }

            return sympt;
        }

        [HttpGet]
        [Route("api/DiagnosisExpertSystem/GetSymptomByid")]
        public async Task<Symptom> GetGetSymptomById(string id)
        {
            Infermedica med = new Infermedica();
            string result = await med.GetSymptomById(id);
            var Symptom = JsonConvert.DeserializeObject<Symptom>(result);
            return Symptom;
        }

        private Symptom GetSymptom(List<Symptom> syms)
        {
            Thread.Sleep(1000);
            Random rnd = new Random();
            Symptom theOne = new Symptom();
            theOne = syms[rnd.Next(0, syms.Count)];
            return theOne;
        }

        [HttpGet]
        [Route("api/DiagnosisExpertSystem/GetConditions")]
        public async Task<List<Symptom>> GetConditions()
        {
            Infermedica med = new Infermedica();
            string result = await med.GetConditions();
            var Symptoms = JsonConvert.DeserializeObject<List<Symptom>>(result)
?? new List<Symptom>();

            return Symptoms;
        }
        [HttpPost]
        [Route("api/DiagnosisExpertSystem/DiagnosePatient")]
        public DiagnosisResponse DiagnosePatient(DiagnosisRequest request)
        {
            Infermedica med = new Infermedica();
            var read = med.DiagnosePatient(request);
            return read;
        }

        [HttpGet]
        [Route("api/DiagnosisExpertSystem/GetAllSymptoms")]
        public async Task<List<Symptom>> GetSymptoms()
        {
            Infermedica med = new Infermedica();
            string result = await med.GetSymptoms();
            var Symptoms = JsonConvert.DeserializeObject<List<Symptom>>(result)
?? new List<Symptom>();
            return Symptoms;
        }

        [HttpGet]
        [Route("api/DiagnosisExpertSystem/GetAllRiskFactors")]
        public async Task<List<RiskFactor>> GetRiskFactors()
        {
            Infermedica med = new Infermedica();
            string result = await med.GetRiskFactors();
            var riskFactors = JsonConvert.DeserializeObject<List<RiskFactor>>(result)
?? new List<RiskFactor>();
            return riskFactors;
        }
    }
}
