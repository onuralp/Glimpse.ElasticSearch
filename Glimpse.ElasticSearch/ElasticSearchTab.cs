using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.AspNet.Extensibility;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Tab.Assist;

namespace Glimpse.ElasticSearch
{
    public class ElasticSearchTab : AspNetTab, ITabLayout
    {
        private static readonly object Layout = TabLayout.Create()
            .Row(r =>
            {
                r.Cell(0).AsKey();
                r.Cell(1).AlignRight().Prefix("T+ ").Suffix(" ms");
                r.Cell(2).AlignRight().Suffix(" ms");
                r.Cell(3).AlignRight();
                r.Cell(4).AlignRight();
                r.Cell(5).AlignRight();
                r.Cell(6).WidthInPercent(60);
            }).Build();

        public override string Name
        {
            get { return "ElasticSearch"; }
        }

        public object GetLayout()
        {
            return Layout;
        }

        public override object GetData(ITabContext context)
        {
            TabSection plugin = Plugin.Create("No", "Started", "Duration", "Method", "Index", "Document", "Query");

            var requestContext = context.GetRequestContext<HttpContextBase>();
            List<RequestItem> items = RequestHandler.GetLogList(requestContext);
            if (items ==null|| !items.Any())
                return null;
            int count = 0;
            foreach (RequestItem item in items)
            {
                plugin.AddRow()
                    .Column(count++)
                    .Column(String.Format("{0:#,0}", item.Time.Subtract(requestContext.Timestamp).TotalMilliseconds))
                    .Column(item.Duration.HasValue
                        ? String.Format("{0:#,0}", item.Duration.Value.TotalMilliseconds)
                        : null)
                    .Column(item.Method)
                    .Column(item.Index)
                    .Column(item.Document)
                    .Column(item.Query);
            }

            return plugin;
        }
    }
}