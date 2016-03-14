using System;
using Glimpse.ElasticSearch;
using NUnit.Framework;

namespace Glimpse.Elasticsearch.Tests
{
    [TestFixture]
    public class UriExtensionsTests
    {
        [Test]
        public void GetSegment_ForIndexEqualToSegmentsCount_ShouldReturnNull()
        {
            var uri = new Uri("http://test-host:9200/index");

            Assert.That(uri.TryGetSegment(2), Is.Null);
        }

        [Test]
        public void GetSegment_ForIndexLessThanSegmentsCount_ShouldReturnSegmentValue()
        {
            var uri = new Uri("http://test-host:9200/index");

            Assert.That(uri.TryGetSegment(1), Is.EqualTo("index"));
        }
    }
}
