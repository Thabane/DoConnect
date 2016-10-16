using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObjectModel;
using ObjectModel.Infermedica_Models;

namespace DataClient
{
    public class Infermedica
    {
        public async Task<string> GetConditions()
        {
            string url = "https://api.infermedica.com/v2/conditions";
            WebRequest myReq = WebRequest.Create(url);

            myReq.Headers["app_id"] = ConfigurationManager.AppSettings["app_id"];
            myReq.Headers["app_key"] = ConfigurationManager.AppSettings["app_key"];
            myReq.ContentType = "application/json";

            WebResponse wr = await myReq.GetResponseAsync();
            Stream receiveStream = wr.GetResponseStream();

            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            var json = content;
            return json;
        }

        public async Task<string> GetSymptoms()
        {
            string url = "https://api.infermedica.com/v2/symptoms";
            WebRequest myReq = WebRequest.Create(url);

            myReq.Headers["app_id"] = ConfigurationManager.AppSettings["app_id"];
            myReq.Headers["app_key"] = ConfigurationManager.AppSettings["app_key"];
            myReq.ContentType = "application/json";

            WebResponse wr = await myReq.GetResponseAsync();
            Stream receiveStream = wr.GetResponseStream();

            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            var json = content;
            return json;
        }

        public async Task<string> GetSymptomById(string id)
        {
            string url = "https://api.infermedica.com/v2/symptoms/";
            string urlWithId = string.Concat(url, id);
            WebRequest myReq = WebRequest.Create(urlWithId);

            myReq.Headers["app_id"] = ConfigurationManager.AppSettings["app_id"];
            myReq.Headers["app_key"] = ConfigurationManager.AppSettings["app_key"];
            myReq.ContentType = "application/json";

            WebResponse wr = await myReq.GetResponseAsync();
            Stream receiveStream = wr.GetResponseStream();

            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            var json = content;
            return json;
        }

        public DiagnosisResponse DiagnosePatient(DiagnosisRequest request)
        {
            var url = "https://api.infermedica.com/v1/diagnosis";
            var jsonData = JsonConvert.SerializeObject(request);

            using (var client = new WebClient())
            {
                client.Headers.Add("app_id", ConfigurationManager.AppSettings["app_id"]);
                client.Headers.Add("app_key", ConfigurationManager.AppSettings["app_key"]);
                client.Headers.Add("content-type", "application/json");
                var result = client.UploadString(url, jsonData);
                var response = JsonConvert.DeserializeObject<DiagnosisResponse>(result);
                return response;
            }
        }

        public async Task<string> GetRiskFactors()
        {
            string url = "https://api.infermedica.com/v2/risk_factors";
            WebRequest myReq = WebRequest.Create(url);

            myReq.Headers["app_id"] = ConfigurationManager.AppSettings["app_id"];
            myReq.Headers["app_key"] = ConfigurationManager.AppSettings["app_key"];
            myReq.ContentType = "application/json";

            WebResponse wr = await myReq.GetResponseAsync();
            Stream receiveStream = wr.GetResponseStream();

            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            var json = content;
            return json;
        }
        public async Task<string> GetConditionById(string id)
        {
            string url = string.Concat("https://api.infermedica.com/v2/conditions/",id);
            WebRequest myReq = WebRequest.Create(url);

            myReq.Headers["app_id"] = ConfigurationManager.AppSettings["app_id"];
            myReq.Headers["app_key"] = ConfigurationManager.AppSettings["app_key"];
            myReq.ContentType = "application/json";

            WebResponse wr = await myReq.GetResponseAsync();
            Stream receiveStream = wr.GetResponseStream();

            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            var json = content;
            return json;
        }
    }
}
