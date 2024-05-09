using System;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json.Nodes;

namespace Client
{
    class webRequests
    {
        public static string WebRequestChuckNorris()
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
                            return (String.Format("Chuck Norris joke: {0}", joke));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

            return "Error";
        }

        public static string WebRequestDadJoke()
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
                            string stringJoke = stringResponse.Split('<')[14].Split('=')[2].Split('/')[0].Remove(0, 1);
                            stringJoke = stringJoke.Remove(stringJoke.Length - 2);

                            return (String.Format("Dad joke: {0}", stringJoke));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

            return "Error";
        }

        public static string WebRequestKanyeQuote()
        {
            const string WEBSERVICE_URL = "https://api.kanye.rest/";
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
                            string quote = ((string)json["quote"]);
                            return (String.Format("Kanye quote: {0}", quote));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

            return ("Error");
        }

        public static string WebRequestRandomJokes()
        {
            const string WEBSERVICE_URL = "https://v2.jokeapi.dev/joke/Any";
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
                            string setup = ((string)json["setup"]);
                            string delivery = ((string)json["delivery"]);
                            return (String.Format("Random joke: {0} \n{1}", setup, delivery));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

            return ("Error");
        }

        public static string WebRequestInsult()
        {
            const string WEBSERVICE_URL = "https://evilinsult.com/generate_insult.php?lang=en&type=json";
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
                            string insult = ((string)json["insult"]);
                            return (String.Format("Insult: {0}", insult));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

            return("Error");
        }

        public static string WebRequestQuote()
        {
            const string WEBSERVICE_URL = "https://api.forismatic.com/api/1.0/?method=getQuote&lang=en&format=jsonp&jsonp=?";
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
                            string quoteString = jsonResponse.Remove(0, 2);
                            quoteString = quoteString.Remove(quoteString.Length - 1);
                            JsonObject json = new JsonObject();
                            json = (JsonObject)JsonObject.Parse(quoteString);
                            string quoteText = ((string)json["quoteText"]);
                            return (String.Format("Motivational quote: {0}", quoteText));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

            return ("Error");
        }

        public static string WebRequestWhatDoesTrumpThink()
        {
            const string WEBSERVICE_URL = "https://api.whatdoestrumpthink.com/api/v1/quotes/random";
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
                            string message = ((string)json["message"]);
                            return (String.Format("What does Trump think: {0}", message));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

            return ("Error");
        }

        public static string WebRequestCatFact()
        {
            const string WEBSERVICE_URL = "https://catfact.ninja/fact";
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
                            string fact = ((string)json["fact"]);
                            return (String.Format("Cat fact: {0}", fact));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

            return ("Error");
        }

        public static string WebRequestActivity()
        {
            const string WEBSERVICE_URL = "https://www.boredapi.com/api/activity";
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
                            string activity = ((string)json["activity"]);
                            return (String.Format("Activity: {0}", activity));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

            return ("Error");
        }  
    }
}

