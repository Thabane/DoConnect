using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataClient;
using ObjectModel;
using ObjectModel.Infermedica_Models;


namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPost();
            Console.WriteLine("Connected");
            Console.ReadKey();
        }

        private static void differentApproach(string jData)
        {
            var url = "https://api.infermedica.com/v1/diagnosis";
            //var jsonData = "{\"sex\": \"male\",\"age\": \"29\",\"evidence\": []}";

            using (var client = new WebClient())
            {
                client.Headers.Add("app_id", ConfigurationManager.AppSettings["app_id"]);
                client.Headers.Add("app_key", ConfigurationManager.AppSettings["app_key"]);
                client.Headers.Add("content-type", "application/json");
                var response = client.UploadString(url, jData);
            }
        }

        public static async void ConnectToAPI()
        {
            var client = new HttpClient();

            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();

            KeyValuePair<string, string> header1 = new KeyValuePair<string, string>("app_id", "152908b1");
            KeyValuePair<string, string> header2 = new KeyValuePair<string, string>("app_key", "63a27bd689544c41f65f35f65bf4c3a2");

            keyValuePairs.Add(header1);
            keyValuePairs.Add(header2);

            // Create the HttpContent for the form to be posted.
            var requestContent = new FormUrlEncodedContent(keyValuePairs);

            // Get the response.
            HttpResponseMessage response = await client.PostAsync(
                "https://api.infermedica.com/v2/info",
                requestContent);

            // Get the response content.
            HttpContent responseContent = response.Content;

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                Console.WriteLine(await reader.ReadToEndAsync());
            }
        }

        public static async void doStuff()
        {
            string url = "https://api.infermedica.com/v2/lab_tests";
            WebRequest myReq = WebRequest.Create(url);
            //myReq.Credentials = new NetworkCredential("152908b1", "63a27bd689544c41f65f35f65bf4c3a2");
            myReq.Headers["app_id"] = ConfigurationManager.AppSettings["app_id"];
            myReq.Headers["app_key"] = ConfigurationManager.AppSettings["app_key"];
            myReq.ContentType = "application/json";

            WebResponse wr = await myReq.GetResponseAsync();
            Stream receiveStream = wr.GetResponseStream();

            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            var json = content;
            //var json = "[" + content + "]"; // change this to array
            //var objects = JArray.Parse(json); // parse as array  

            //foreach (JObject o in objects.Children<JObject>())
            //{
            //    foreach (JProperty p in o.Properties())
            //    {
            //        string name = p.Name;
            //        string value = p.Value.ToString();
            //        Console.Write(name + ": " + value);
            //    }
            //}
            Console.ReadLine();
        }

        public static void TestPost()
        {
            Infermedica med = new Infermedica();
            DiagnosisRequest dRequest = new DiagnosisRequest();
            dRequest.age = "25";
            dRequest.sex = Sex.male.ToString();
            dRequest.evidence = new List<Evidence>();
            dRequest.evidence.Add(new Evidence() {id = "s_721", choice_id = ChoiceId.present.ToString()});            
            dRequest.evidence.Add(new Evidence() {id = "s_16", choice_id = ChoiceId.present.ToString()});            
            dRequest.evidence.Add(new Evidence() {id = "s_661", choice_id = ChoiceId.present.ToString()});            
            //["s_721", "s_661"]
            DiagnosisResponse res = med.DiagnosePatient(dRequest);
        }

        public static async void Fire()
        {
            Infermedica med = new Infermedica();
            var hold = await med.GetConditionById("c_10");
        }

        
    }
}
