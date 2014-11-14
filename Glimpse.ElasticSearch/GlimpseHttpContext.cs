using System;
using System.Net;
using System.Text;
using Elasticsearch.Net.Connection;
using Elasticsearch.Net.Connection.Configuration;

namespace Glimpse.ElasticSearch
{
    public class GlimpseHttpConnection : HttpConnection
    {
        public GlimpseHttpConnection(IConnectionConfigurationValues settings)
            : base(settings)
        {
        }

        protected override HttpWebRequest CreateHttpWebRequest(Uri uri, string method, byte[] data,
            IRequestConfiguration requestSpecificConfig)
        {
            DateTime tsStart = DateTime.Now;
            HttpWebRequest request = base.CreateHttpWebRequest(uri, method, data, requestSpecificConfig);
            TimeSpan timeSpan = DateTime.Now.Subtract(tsStart);

            RequestHandler.Add(tsStart, timeSpan, request.Method, uri, Encoding.UTF8.GetString(data));

            return request;
        }
    }
}