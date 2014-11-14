Glimpse.ElasticSearch
=====================

Description
-----------

A simple Glimpse plugin for ElasticSearch. It shows queries and response times.

Usage
-----
You must create ElasticClient instance with GlimpseHttpConnection That's it.

    var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
    var client = new ElasticClient(settings, new GlimpseHttpConnection(settings));

Screenshot
----------

![Sample screenshot](/screenshots/glimpse-elasticsearch.png "Query details")

Support
-------

Create an issue here on GitHub, send me a message or fork the project and send me a pull request.