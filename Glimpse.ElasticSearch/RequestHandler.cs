using System;
using System.Collections.Generic;
using System.Web;

namespace Glimpse.ElasticSearch
{
    internal static class RequestHandler
    {
        internal const string Key = "Glimpse.ElasticSearch";

        private static readonly object ContextLock = new object();

        internal static List<RequestItem> GetLogList(HttpContextBase context)
        {
            if (context == null)
                return null;

            var items = context.Items[Key] as List<RequestItem>;

            return items;
        }

        public static void Add(DateTime time, TimeSpan duration, string method, Uri uri, string query)
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
                return;

            var requestItem = new RequestItem
            {
                Time = time,
                Duration = duration,
                Method = method,
                Index = GetSegment(uri, 1),
                Document = GetSegment(uri, 2),
                Endpoint = GetSegment(uri, 3),
                Query = query
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

        private static string GetSegment(Uri uri, int index)
        {
            return uri.Segments.Length >= index ? uri.Segments[index].Trim('/') : null;
        }
    }
}