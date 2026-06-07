using GymSystem.DAL.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Controllers
{
    public class PlanController : Controller
    {
        // Start Connection to Database
        //public readonly GymAppContext _context;

        private readonly IPlanRepo _planRepo;

        public PlanController(IPlanRepo planRepo)
        {
            _planRepo = planRepo;
        }
        // GET :: /Plan/Index
        public async Task<IActionResult> Index(CancellationToken ct = default)
        {
            var plans = await _planRepo.GetAllPlansAsync(ct: ct);
            return View(plans);
        }

        // GET :: /Plan/Detials/{id}

        public async Task<IActionResult> Details(int id, CancellationToken ct = default)
        {
            var plan = await _planRepo.GetPlanByIDAsync(id, ct);
            if (plan == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}
