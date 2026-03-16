using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using FirstWebApp.Models;
using System.Text;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistributedCache _cache;
        private readonly AppDbContext _context;

        // Dependency Injection for both SQL (DbContext) and Redis (Cache)
        public HomeController(IDistributedCache cache, AppDbContext context)
        {
            _cache = cache;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string currentTime = DateTime.Now.ToString();
            
            await _cache.SetStringAsync("LastVisitTime", currentTime);

            ViewBag.RedisData = await _cache.GetStringAsync("LastVisitTime");
            
            ViewBag.StudentCount = _context.Students.Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}