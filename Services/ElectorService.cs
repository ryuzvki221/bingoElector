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
    public class ElectorService : IElectorRepository
    {
        private readonly MongoDBContext _context;

        public ElectorService(IOptions<Settings> settings)
        {
            _context = new MongoDBContext(settings);
        }

        //Get all elector

        public async Task<IEnumerable<Elector>> GetAllElectors()
        {
            try
            {
                return await _context.Electors.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after Id or InternalId (BSonId value)
        public async Task<Elector> GetElector(string id)
        {
            var filter = Builders<Elector>.Filter.Eq("Id", id);

            try
            {

                return await _context.Electors
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Add new elector document

        public async Task AddElector(Elector item)
        {
            try
            {
                await _context.Electors.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }

        }

        // Update an existing elector document

        public async Task<bool> UpdateElector(string id,  string lieuDeResidence, string bureau)
        {


            var filter = Builders<Elector>.Filter.Eq(s => s.Id, id);
            var update = Builders<Elector>.Update
                            .Set(s => s.LieuDeResidence, lieuDeResidence)
                            .Set(s => s.BureauId, bureau)
                            .CurrentDate(s => s.UpdatedOn);

            try
            {
                UpdateResult actionResult = await _context.Electors.UpdateOneAsync(filter, update);
                return actionResult.IsAcknowledged
                        && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Remove a single elector document

        public async Task<bool> RemoveElector(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Electors.DeleteOneAsync(
                     Builders<Elector>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Remove all electors documents

        public async Task<bool> RemoveAllElectors()
        {
            try
            {
                DeleteResult actionResult = await _context.Electors.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;

            }
        }

        // it creates a sample compound index (first using BureauId, and then Body)
        // 
        // MongoDb automatically detects if the index already exists - in this case it just returns the index details

        public async Task<string> CreateIndex()
        {
            try
            {
                IndexKeysDefinition<Elector> keys = Builders<Elector>
                                                    .IndexKeys
                                                    .Ascending(item => item.BureauId)
                                                    .Ascending(item => item.LastName);

                return await _context.Electors
                                .Indexes.CreateOneAsync(new CreateIndexModel<Elector>(keys));
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // // Try to convert the Id to a BSonId value
        // private ObjectId GetInternalId(string id)
        // {
        //     if (!ObjectId.TryParse(id, out ObjectId internalId))
        //         internalId = ObjectId.Empty;

        //     return internalId;
        // }
    }
}