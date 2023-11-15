using System;
using System.Net;
using System.Net.Http.Headers;

namespace Demo_API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://realstonks.p.rapidapi.com/TSLA"),
                Headers =
        {
        { "X-RapidAPI-Key", "5c3afdf750mshcb609474fdf75f8p11e8d2jsn2e1379fc5687" },
        { "X-RapidAPI-Host", "realstonks.p.rapidapi.com" },
        },
        };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}