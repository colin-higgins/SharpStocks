using System.Collections.Generic;
using System.Security.Cryptography;

namespace SharpStocks.Data
{
    public class Company : IModifiable
    {
        public Oid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public StockExchange StockExchange { get; set; }
        public Sector Sector { get; set; }
        public string SubSector { get; set; }
        public string Description { get; set; }
        public bool Verified { get; set; }

        public Quote LatestQuote { get; set; }
        public IList<Quote> HistoricalQuotes { get; set; }
    }
}