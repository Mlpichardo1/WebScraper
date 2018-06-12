using System;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;

namespace WebScraperApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHtmlAsync();
            Console.ReadLine();
        }

        private static async void GetHtmlAsync()
        {
            var url = "https://finance.yahoo.com/portfolio/p_1/view/v1?bypass=true";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var stockHtml = htmlDocument.DocumentNode.Descendants("table")
            .Where(node => node.GetAttributeValue("data-test", "")
            .Equals("contentTable")).ToList();
            
            var stockListItems = stockHtml[0]
            // var stockList = stockHtml[0].Descendants()

            System.Console.WriteLine();
        }
    }
}


