using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace Mongo.Models
{
    public class MongoAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
        public MongoAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("PubDBOrders");
        }

        public IEnumerable<Order> GetOrders()
        {
            return _db.GetCollection<Order>("Orders").FindAll();
        }

        public Order Create(Order p)
        {
            _db.GetCollection<Order>("Orders").Save(p);
            return p;
        }
    }
}