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
        [Route("api/DiagnosisExpertSystem/GetSymptoms")]
        public async Task<List<Symptom>> GetSymptoms()
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
            theOne = syms[rnd.Next(0,syms.Count)];
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
        [HttpGet]
        [Route("api/DiagnosisExpertSystem/DiagnosePatient")]
        public DiagnosisResponse DiagnosePatient()
        {
            Infermedica med = new Infermedica();
            DiagnosisRequest dRequest =  new DiagnosisRequest();
            dRequest.age = 25;
            dRequest.sex = Sex.male.ToString();
            dRequest.evaluated_at = "Roodepoort, 15 September 2016";
            dRequest.evidence = new List<Evidence>();
            dRequest.evidence.Add(new Evidence() {id = "s_721",choice_id = ChoiceId.present.ToString()});
            //["s_721", "s_661"]
            DiagnosisResponse res = med.DiagnosePatient(dRequest);
            return res;
        }
    }
}
