using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Elasticsearch.Net;
using Glimpse.ElasticSearch;
using Nest;

namespace Glimpse.Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var connectionPool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));

            var settings = new ConnectionSettings(connectionPool)
                .DefaultIndex("product")
                .DisableDirectStreaming()
                .OnRequestCompleted(RequestHandler.OnRequestCompletedHandler);
            var client = new Nest.ElasticClient(settings);
            
            ISearchResponse<EsDocument> data = client.Search<EsDocument>(s => s.Query(q=>q.MatchAll()));
            
            return View(data.Documents);
        }
    }

    [ElasticsearchType(Name = "document")]
    public class EsDocument
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}