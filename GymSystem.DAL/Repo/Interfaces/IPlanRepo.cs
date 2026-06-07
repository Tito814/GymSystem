using GymSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DAL.Repo.Interfaces
{
    public interface IPlanRepo
    {
        // Get all plans
        Task<IEnumerable<Plan>> GetAllPlansAsync(bool tracking = false, CancellationToken ct = default);
        // Get a plan by ID
        Task<Plan> GetPlanByIDAsync(int id, CancellationToken ct = default);
        // Add a new plan
        Task<int> AddAsync(Plan plan, CancellationToken ct = default);
        // Update an existing plan
        Task<int> UpdateAsync(Plan plan, CancellationToken ct = default);
        // Delete a plan
        Task<int> DeleteAsync(Plan plan, CancellationToken ct = default);
    }
}
