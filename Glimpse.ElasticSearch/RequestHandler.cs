using System.Collections.Generic;
using System.Text;
using System.Web;
using Elasticsearch.Net;

namespace Glimpse.ElasticSearch
{
    public static class RequestHandler
    {
        internal const string Key = "Glimpse.ElasticSearch";

        private static readonly object ContextLock = new object();

        internal static List<RequestItem> GetLogList(HttpContextBase context)
        {
            var items = context?.Items[Key] as List<RequestItem>;

            return items;
        }

        public static void OnRequestCompletedHandler(IApiCallDetails apiCallDetails)
        {
            var context = HttpContext.Current;
            if (context == null)
                return;

            var requestItem = new RequestItem
            {
                HttpMethod = apiCallDetails.HttpMethod.ToString(),
                HttpStatus = apiCallDetails.HttpStatusCode.ToString(),
                Index = apiCallDetails.Uri.TryGetSegment(1),
                Document = apiCallDetails.Uri.TryGetSegment(2),
                Endpoint = apiCallDetails.Uri.TryGetSegment(3),
                Query = Encoding.UTF8.GetString(apiCallDetails.RequestBodyInBytes ?? new byte[0]),
                ResponseData = Encoding.UTF8.GetString(apiCallDetails.ResponseBodyInBytes ?? new byte[0])
            };

            if (context.Items[Key] == null)
                lock (ContextLock)
                {
                    if (context.Items[Key] == null)
                        context.Items[Key] = new List<RequestItem>();
                }

            var items = context.Items[Key] as List<RequestItem>;
            items.Add(requestItem);
        }
    }
}