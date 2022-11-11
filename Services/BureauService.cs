using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using bingoElector.Models;
using bingoElector.Repositories;

using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization;

namespace bingoElector.Services
{
    public class BureauService : IBureauRepository
    {
        private readonly MongoDBContext _context;

        public BureauService(IOptions<Settings> settings)
        {
            _context = new MongoDBContext(settings);
        }


        //Get all bureau

        public async Task<IEnumerable<Bureau>> GetBureaux()
        {
            try
            {
                return await _context.Bureaux.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after Id or InternalId (BSonId value)
        public async Task<Bureau> GetBureau(string id)
        {
            var filter = Builders<Bureau>.Filter.Eq("Id", id);

            try
            {

                return await _context.Bureaux
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Add new bureau document

        public async Task AddBureau(Bureau item)
        {
            try
            {
                await _context.Bureaux.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        // Update just a single document / bureau
        public async Task<bool> UpdateBureau(string id, string name, int capacite)
        {
            var filter = Builders<Bureau>.Filter.Eq(s => s.Id, id);
            var update = Builders<Bureau>.Update
                            .Set(s => s.Name, name)
                            .Set(s => s.Capacite, capacite);

            try
            {
                UpdateResult actionResult = await _context.Bureaux.UpdateOneAsync(filter, update);
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Remove single document / bureau
        public async Task<bool> RemoveBureau(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Bureaux.DeleteOneAsync(
                     Builders<Bureau>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Remove all documents / bureaux
        public async Task<bool> RemoveAllBureaux()
        {
            try
            {
                DeleteResult actionResult = await _context.Bureaux.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


    }
}