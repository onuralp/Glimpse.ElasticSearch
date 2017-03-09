namespace Glimpse.ElasticSearch
{
    internal class RequestItem
    {
        public string HttpMethod;
        public string Query;
        public string ResponseData;
        public string Document { get; set; }
        public string Index { get; set; }
        public string Endpoint { get; set; }
        public string HttpStatus { get; set; }
    }
}