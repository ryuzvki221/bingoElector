using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using bingoElector.Models;
using bingoElector.Repositories;

using MongoDB.Driver.Linq;

namespace bingoElector.Services
{
    public class CentreService : ICentreRepository
    {

        private readonly MongoDBContext _context;

        public CentreService(IOptions<Settings> settings)
        {
            _context = new MongoDBContext(settings);
        }

        //Get all centres

        public async Task<IEnumerable<Centre>> GetCentres()
        {
            try
            {
                return await _context.Centres.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after Id or InternalId (BSonId value)
        public async Task<Centre> GetCentre(string id)
        {
            var filter = Builders<Centre>.Filter.Eq("Id", id);

            try
            {

                return await _context.Centres
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Add new centre document
        public async Task AddCentre(Centre item)
        {
            try
            {
                await _context.Centres.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Update a centre document
        public async Task<bool> UpdateCentre(string id, string name, string address, int nombreDeSalle)
        {
            var filter = Builders<Centre>.Filter.Eq(s => s.Id, id);
            var update = Builders<Centre>.Update
                            .Set(s => s.Name, name)
                            .Set(s => s.Address, address)
                            .Set(s => s.NombreDeSalle, nombreDeSalle);
            try
            {
                UpdateResult actionResult = await _context.Centres.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Remove all centres document
        public async Task<bool> RemoveAllCentres()
        {
            try
            {
                DeleteResult actionResult = await _context.Centres.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Remove a centre document
        public async Task<bool> RemoveCentre(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Centres.DeleteOneAsync(
                     Builders<Centre>.Filter.Eq("Id", id));

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