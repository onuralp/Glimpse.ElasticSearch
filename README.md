Glimpse.ElasticSearch
=====================

Description
-----------

[![NuGet](https://img.shields.io/nuget/v/Glimpse.ElasticSearch.svg)](https://www.nuget.org/packages/Glimpse.ElasticSearch)  [![Build status](https://ci.appveyor.com/api/projects/status/0kigtj1io5qaggmi?svg=true)](https://ci.appveyor.com/project/OnuralpTaner54458/glimpse-elasticsearch)  [![Build Status](https://travis-ci.org/onuralp/Glimpse.ElasticSearch.svg)](https://travis-ci.org/onuralp/Glimpse.ElasticSearch)

A simple Glimpse plugin for ElasticSearch. It shows queries and response times.

Usage
-----
You must add RequestHandler.OnRequestCompletedHandler to the OnRequestCompleted event when creating the ConnectionSettings. That's it.

    var settings = new ConnectionSettings(connectionPool)
                .OnRequestCompleted(RequestHandler.OnRequestCompletedHandler);
    var client = new ElasticClient(settings);

Screenshot
----------

![Sample screenshot](/screenshots/glimpse-elasticsearch.png "Query details")


### TODO

*(Feel free to pick something below.)*

- [x] Add nuspec file and push it to the nuget.
- [ ] Add a sample project about how to use.
- [ ] Write a blog post about this.

Support
-------

Create an issue here on GitHub, send me a message or fork the project and send me a pull request.