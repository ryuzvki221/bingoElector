using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bingoElector.Models
{
    public class Bureau
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacite { get; set; }
        // many to one relationship : many bureau -> one centre
        [BsonElement("Centre")]
        [JsonPropertyName("Centre")]
        public string? CentreId { get; set; }
        // one to many relationship : one bureau can have many electors
        [BsonElement("Electors")]
        [JsonPropertyName("Electors")]
        public List<string>? ElectorIds { get; set; }
    }
}
