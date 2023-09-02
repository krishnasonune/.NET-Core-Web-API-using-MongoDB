using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Crud_with_mongodb.Models;
public class Users
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Todo Todo { get; set; }
}


