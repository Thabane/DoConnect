using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataClient;
using Newtonsoft.Json.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //ConnectToAPI();
            doStuff();

            Console.WriteLine("Connected");
            Console.ReadKey();
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
            string url = "https://api.infermedica.com/v2/info";
            WebRequest myReq = WebRequest.Create(url);

            myReq.Headers["app_id"] = "152908b1";
            myReq.Headers["app_key"] = "63a27bd689544c41f65f35f65bf4c3a2";
            WebResponse wr = await myReq.GetResponseAsync();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            //Console.WriteLine(content);
            var json = "[" + content + "]"; // change this to array
            var objects = JArray.Parse(json); // parse as array  

            foreach (JObject o in objects.Children<JObject>())
            {
                foreach (JProperty p in o.Properties())
                {
                    string name = p.Name;
                    string value = p.Value.ToString();
                    Console.Write(name + ": " + value);
                }
            }
            Console.ReadLine();
        }
    }
}
