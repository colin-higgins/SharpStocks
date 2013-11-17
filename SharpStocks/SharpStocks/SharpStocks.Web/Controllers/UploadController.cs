using System;
using System.Web;
using System.Web.Mvc;
using SharpStocks.Data;

namespace SharpStocks.Web.Controllers
{
    public class UploadController : Controller
    {
        private SharpStocksContext _context;

        public UploadController()
        {
            _context = new SharpStocksContext();
        }

        private void UploadCSV(HttpPostedFile csv)
        {
            throw new NotImplementedException();
        }

        private void ParseNasdaqCSV(string filename)
        {
            var uploader = new FileHelpers.CsvEngine("NasdaqCompany", ',', 9);

        }

        public class NasdaqCompany
        {
            public string Symbol { get; set; }
            public string Name { get; set; } 
            public decimal LastSale { get; set; } 
            public decimal MarketCap { get; set; } 
            public string ADRTSO { get; set; } 
            public int IPOyear { get; set; } 
            public string Sector { get; set; } 
            public string Industry { get; set; } 
            public string SummaryQuote { get; set; } 
        }
    }
}