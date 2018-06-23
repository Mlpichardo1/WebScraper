namespace WebScraperApp.Models
{
    public class StockModel
    {
        public string Symbol {get; set;}
        public decimal AverageVolume {get; set;}
        public decimal ListTradePrice {get; set;}


    }

    public static class YahooFinance
    {
        public static List<StockModel> Parse(string csvData)
        {
            try 
            {
                List<StockModel> stocks = new List<StockModel>();
                string[] row =  csvData 

            }
            catch(Exception ex)
            {
                // handle error
                string error = ex.Message.toString();
            }
            return null;
        }


    }
}