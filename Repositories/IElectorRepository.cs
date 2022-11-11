using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bingoElector.Models;

namespace bingoElector.Repositories
{
    public interface IElectorRepository
    {

        // Get all electors
        Task<IEnumerable<Elector>> GetAllElectors();
        // Get elector by id
        Task<Elector> GetElector(string id);
        // Add new elector document
        Task AddElector(Elector item);
        // Remove a single document / elector
        Task<bool> RemoveElector(string id);
        // Update just a single document / elector
        Task<bool> UpdateElector(string id, string lastName, string firstName, string lieuDeResidence, string bureau);
        // Remove all electors
        Task<bool> RemoveAllElectors();

        //create index
        Task<string> CreateIndex();
    }
}