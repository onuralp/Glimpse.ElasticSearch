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


### TODO

*(Feel free to pick something below.)*

- [ ] Add nuspec file and push it to the nuget.
- [ ] Add a sample project about how to use.
- [ ] Write a blog post about this.

Support
-------

Create an issue here on GitHub, send me a message or fork the project and send me a pull request.