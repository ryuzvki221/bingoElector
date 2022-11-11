using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bingoElector.Models
{
    public class Elector
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LieuDeResidence { get; set; } = string.Empty;
        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        // many to one relationship : one elector can have one bureau
        [BsonElement("Bureau")]
        [JsonPropertyName("Bureau")]
        public string BureauId { get; set; } = string.Empty;

    }
}
