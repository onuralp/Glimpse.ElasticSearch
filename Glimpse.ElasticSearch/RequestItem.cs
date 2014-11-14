using System;

namespace Glimpse.ElasticSearch
{
    internal class RequestItem
    {
        public TimeSpan? Duration;
        public string Method;
        public string Query;
        public DateTime Time = DateTime.Now;
        public string Document { get; set; }
        public string Index { get; set; }
    }
}