using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Ambev.DeveloperEvaluation.ORM.Mongo;

public class MongoHelper
{
    private readonly MongoClient _client;
    public MongoContext Context { get; private set; }

    public MongoHelper(ConfigurationManager configurationManager)
    {
        var connString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING") ?? configurationManager.GetConnectionString("MongoConnection");
        _client ??= new MongoClient(connString);
        Context ??= MongoContext.Create(_client.GetDatabase("DeveloperEvaluation"));
    }
}