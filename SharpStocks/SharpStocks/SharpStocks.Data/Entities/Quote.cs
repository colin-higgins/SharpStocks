using System;

namespace SharpStocks.Data
{
    public class Quote : IModifiable
    {
        public DateTime RetrieveDateTime { get; set; }
        public DateTime QuoteDateTime { get; set; }
        public decimal DayLow { get; set; }
        public decimal DayHigh { get; set; }
        public decimal Open { get; set; }
        public decimal Volume { get; set; }
        public string Notes { get; set; }
    }
}