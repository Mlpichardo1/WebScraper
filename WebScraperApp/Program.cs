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
            
            var StockListItems = stockHtml[0].Descendants("tr")
            .Where(node => node.GetAttributeValue("data-key", "")
            .Contains("")).ToList();
            // var stockList = stockHtml[0].Descendants()

            foreach (var StockListItem in StockListItems)
            {
                System.Console.WriteLine(StockListItem.GetAttributeValue("data-key", ""));

                System.Console.WriteLine(StockListItem.Descendants("tr")
                .Where(node => node.GetAttributeValue("class", "")
                );
            }
        }
    }
}


