using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    public class Order
    {
        public ObjectId Id { get; set; }

        [BsonElement("OrderID")]
        public int OrderID { get; set; }

        [BsonElement("From")]
        public string From { get; set; }

        [BsonElement("To")]
        public string To { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

        [BsonElement("TotalPrice")]
        public string TotalPrice{ get; set; }

        [BsonElement("ProductsInfo")]
        public string ProductsInfo { get; set; }
    }
}