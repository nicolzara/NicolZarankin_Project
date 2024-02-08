using System.Net;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace RandomDataAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebRequest();
            
        }

        public static void WebRequest()
        {
            const string WEBSERVICE_URL = "https://randomfacts-api.p.rapidapi.com/random";
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.Headers.Add("X-RapidAPI-Key", "70e11b6971msheecdcf2cb7d9876p13caa5jsnbaffc38cd0ab");
                    webRequest.Headers.Add("X-RapidAPI-Host", "randomfacts-api.p.rapidapi.com");

                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            Console.WriteLine(String.Format("Response: {0}", jsonResponse));
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

