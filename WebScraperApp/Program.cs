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

            var stockHtml = htmlDocument.DocumentNode.Descendants("div")
            .Where(node => node.GetAttributeValue("id", "")
            .Equals("_container_")).ToList();
            
            var StockListItems = stockHtml[0].Descendants("section")
            .Where(node => node.GetAttributeValue("data-test", "")
            .Contains("tableContainer")).ToList();
            // var stockList = stockHtml[0].Descendants()

            foreach (var StockListItem in StockListItems)
            {
                System.Console.WriteLine(StockListItem.GetAttributeValue("table", ""));

                // Stock Name
                System.Console.WriteLine(StockListItem.Descendants("tbody")
                .Where(node => node.GetAttributeValue("tr", "")
                .Equals("data-key")).FirstOrDefault().InnerText.Trim('\r', '\n')
                );
            }
        }
    }
}


