using System.Collections.Generic;
using System.Security.Cryptography;
using SharpStocks.Data;

namespace SharpStocks.Web.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel(Company company)
        {
            Id = company.Id;
            Name = company.Name;
            Symbol = company.Symbol;
            Sector = company.Sector;
            Description = company.Description;
            StockExchange = company.StockExchange;
        }

        public CompanyViewModel()
        {
        }

        public Oid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public Sector Sector { get; set; }
        public string Description { get; set; }
        public string StockExchange { get; set; }

        public Quote LatestQuote { get; set; }
        public IList<Quote> HistoricalQuotes { get; set; }
    }
}