using System;
using System.Net.Http;

namespace WebScraperApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://finance.yahoo.com/portfolio/p_1/view/v1?bypass=true";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url);

            System.Console.WriteLine(html.Result);
            Console.ReadLine();
        }
    }
}


