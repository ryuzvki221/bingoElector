using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bingoElector.Models;

namespace bingoElector.Repositories
{
    public interface ICentreRepository
    {
        // Get all centers
        Task<IEnumerable<Centre>> GetCentres();
        // Get center by id
        Task<Centre> GetCentre(string id);
        // Add new center document
        Task AddCentre(Centre item);
        // Remove a single document / center
        Task<bool> RemoveCentre(string id);
        // Update just a single document / center
        Task<bool> UpdateCentre(string id, string name, string address, int nombreDeSalle);
        // Remove all centers
        Task<bool> RemoveAllCentres();
    }
}