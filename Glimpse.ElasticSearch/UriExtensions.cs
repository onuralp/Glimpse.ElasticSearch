using System;

namespace Glimpse.ElasticSearch
{
    public static class UriExtensions
    {
        public static string GetSegment(this Uri uri, int index)
        {
            return uri.Segments.Length >= index ? uri.Segments[index].Trim('/') : null;
        }
    }
}