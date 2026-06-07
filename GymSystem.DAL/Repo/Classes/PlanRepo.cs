using GymSystem.DAL.Repo.Interfaces;
using GymSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DAL.Repo.Classes
{
    public class PlanRepo : IPlanRepo
    {
        private readonly GymAppContext _context;

        public PlanRepo(GymAppContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Plan plan, CancellationToken ct = default)
        {
            _context.Plans.Add(plan);
            return await _context.SaveChangesAsync(ct);
        }

        public async Task<int> DeleteAsync(Plan plan, CancellationToken ct = default)
        {
            _context.Plans.Remove(plan);
            return await _context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<Plan>> GetAllPlansAsync(bool tracking = false, CancellationToken ct = default)
        {
            if (tracking)
            {
                return await _context.Plans.ToListAsync(ct);
            }
            else
            {
                return await _context.Plans.AsNoTracking().ToListAsync(ct);
            }
        }

        public async Task<Plan> GetPlanByIDAsync(int id, CancellationToken ct = default)
        {
            return await _context.Plans.FindAsync(id , ct);
        }

        public Task<int> UpdateAsync(Plan plan, CancellationToken ct = default)
        {
            _context.Plans.Update(plan);
            return _context.SaveChangesAsync(ct);
        }
    }
}
