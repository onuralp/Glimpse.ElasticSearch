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
                r.Cell(1).AlignRight();
                r.Cell(2).AlignRight();
                r.Cell(3).AlignRight();
                r.Cell(4).AlignRight();
                r.Cell(5).AlignRight();
                r.Cell(6).AlignRight().WidthInPercent(20);
                r.Cell(7).AlignRight().WidthInPercent(20);
            })
            .Build();

        public override string Name => "ElasticSearch";

        public object GetLayout()
        {
            return Layout;
        }

        public override object GetData(ITabContext context)
        {
            var plugin = Plugin.Create("No", "Status", "HttpMethod", "Index", "Document", "Endpoint", "Query",
                "ResponseData");

            var requestContext = context.GetRequestContext<HttpContextBase>();
            var items = RequestHandler.GetLogList(requestContext);
            if (items == null || !items.Any())
                return null;
            var count = 1;
            foreach (var item in items)
                plugin.AddRow()
                    .Column(count++)
                    .Column(item.HttpStatus)
                    .Column(item.HttpMethod)
                    .Column(item.Index)
                    .Column(item.Document)
                    .Column(item.Endpoint)
                    .Column(item.Query)
                    .Column(item.ResponseData);

            return plugin;
        }
    }
}