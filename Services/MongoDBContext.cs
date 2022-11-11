using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using bingoElector.Models;

namespace bingoElector.Services
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

          public MongoDBContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
            


        }

        // Get collection of electors
        public IMongoCollection<Elector> Electors
        {
            get
            {
                return _database.GetCollection<Elector>("electors");
            }
        }

        // Get collection of centres
        public IMongoCollection<Centre> Centres
        {
            get
            {
                return _database.GetCollection<Centre>("centres");
            }
        }

        // Get collection of bureaux
        public IMongoCollection<Bureau> Bureaux
        {
            get
            {
                return _database.GetCollection<Bureau>("bureaux");
            }
        }
    }



}