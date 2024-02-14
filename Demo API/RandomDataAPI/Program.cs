using System.Net;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace RandomDataAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebRequestChuckNorris();
            WebRequestDadJoke();
            
        }

        public static void WebRequestChuckNorris()
        {
            const string WEBSERVICE_URL = "https://api.chucknorris.io/jokes/random";
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;

                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            JsonObject json = new JsonObject();
                            json = (JsonObject)JsonObject.Parse(jsonResponse);
                            string joke = ((string)json["value"]);
                            Console.WriteLine(String.Format("Response: {0}", joke));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void WebRequestDadJoke()
        {
            const string WEBSERVICE_URL = "https://icanhazdadjoke.com/";
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;

                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var stringResponse = sr.ReadToEnd(); 
                            string stringJoke = stringResponse.Split('\n')[13].Split('=')[2];
                            
                            Console.WriteLine(String.Format("Response: {0}", stringJoke));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

