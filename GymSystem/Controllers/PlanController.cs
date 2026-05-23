using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Controllers
{
    public class PlanController : Controller
    {
        // Start Connection to Database
        public readonly GymAppContext _context;
        public PlanController()
        {
            _context = new GymAppContext();
        }
        // GET :: /Plan/Index
        public async Task<IActionResult> Index()
        {
            var plans = await _context.Plans.ToListAsync();
            return View(plans);
        }

        // GET :: /Plan/Detials/{id}

        public async Task<IActionResult> Details(int id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}
