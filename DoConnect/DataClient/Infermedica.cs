using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
            Console.WriteLine(content);
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
            Console.WriteLine(content);
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
    }
}
