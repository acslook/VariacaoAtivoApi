using System.Diagnostics.CodeAnalysis;

namespace VariacaoAtivoApi.Domain.Models
{    
    public class HistoricoAtivo
    {
        public Chart chart { get; set; }
    }

    public class Chart
    {
        public Result[] result { get; set; }
    }

    public class Result
    {
        public Meta meta { get; set; }
        public long[] timestamp { get; set; }
        public Indicators indicators { get; set; }
    }

    public class Meta
    {
        public string currency { get; set; }
        public string symbol { get; set; }
        public string exchangeName { get; set; }
        public string instrumentType { get; set; }
        public long firstTradeDate { get; set; }
        public long regularMarketTime { get; set; }
        public long gmtoffset { get; set; }
        public string timezone { get; set; }
        public string exchangeTimezoneName { get; set; }
        public decimal regularMarketPrice { get; set; }
        public decimal chartPreviousClose { get; set; }
        public decimal previousClose { get; set; }
        public long scale { get; set; }
        public long priceHint { get; set; }
        public Currenttradingperiod currentTradingPeriod { get; set; }
        public Tradingperiod[][] tradingPeriods { get; set; }
        public string dataGranularity { get; set; }
        public string range { get; set; }
        public string[] validRanges { get; set; }
    }

    public class Currenttradingperiod
    {
        public Pre pre { get; set; }
        public Regular regular { get; set; }
        public Post post { get; set; }
    }

    public class Pre
    {
        public string timezone { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public long gmtoffset { get; set; }
    }

    public class Regular
    {
        public string timezone { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public long gmtoffset { get; set; }
    }

    public class Post
    {
        public string timezone { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public long gmtoffset { get; set; }
    }

    public class Tradingperiod
    {
        public string timezone { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public long gmtoffset { get; set; }
    }

    public class Indicators
    {
        public Quote[] quote { get; set; }
    }

    public class Quote
    {
        public decimal?[] open { get; set; }
        public decimal?[] high { get; set; }
        public long?[] volume { get; set; }
        public decimal?[] low { get; set; }
        public decimal?[] close { get; set; }
    }

}
