using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bingoElector.Models
{
    public class Centre
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int NombreDeSalle { get; set; }

        // one to many relationship : one centre can have many bureaux
        [BsonElement("Bureaux")]
        [JsonPropertyName("Bureaux")]
        public List<string>? BureauIds { get; set; }

    }
}
