using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bingoElector.Models;

namespace bingoElector.Repositories
{
    public interface IBureauRepository
    {

        // Get all bureaus
        Task<IEnumerable<Bureau>> GetBureaux();
        // Get bureau by id
        Task<Bureau> GetBureau(string id);
        // Add new bureau document
        Task AddBureau(Bureau item);
        // Remove a single document / bureau
        Task<bool> RemoveBureau(string id);
        // Update just a single document / bureau
        Task<bool> UpdateBureau(string id, string name ,int capacite);
        // Remove all bureaus
        Task<bool> RemoveAllBureaux();

    }
}