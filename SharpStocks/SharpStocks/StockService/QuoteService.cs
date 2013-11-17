using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yahoo = YSQ.core;
using QuoteEnum = YSQ.core.QuoteReturnParameter;

namespace StockService
{
    public class QuoteService
    {
        private readonly yahoo.QuoteService _quoteService;

        public QuoteService()
        {
            _quoteService = new yahoo.QuoteService();
        }

        public IEnumerable<Quote> Test()
        {
            var tickers = new[]
            {
                "MSFT",
                "GOOG",
                "YHOO",
                "BAS.DE",
                "ALV.DE",
            };

            var quoteRequest = _quoteService.Quote(tickers);

            var returnParams = new[]
            {
                QuoteEnum.Name,
                QuoteEnum.Symbol,
                QuoteEnum.Open,
                QuoteEnum.Change,
                QuoteEnum.StockExchange
            };

            var quotesRaw = quoteRequest.Return(returnParams);

            var quotes = new List<Quote>();

            foreach (var q in quotesRaw)
            {
                var quote = new Quote()
                {
                    Symbol = q["Symbol"],
                    Name = q["Name"],
                    StockExchange = q["StockExchange"],
                };

                decimal open, change;

                decimal.TryParse(q["Open"], out open);
                decimal.TryParse(q["Change"], out change);
                quote.Open = open;
                quote.Change = change;

                quotes.Add(quote);
            }

            return quotes;
        }
    }

    public class Quote
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string StockExchange { get; set; }
        public decimal Open { get; set; }
        public decimal Change { get; set; }
    }
}
