using Microsoft.AspNetCore.Mvc;
using FirstWebApp.Models;

namespace FirstWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // READ: Display all students
        public IActionResult Index()
        {
            var data = _context.Students.ToList();
            return View(data);
        }

        // CREATE: Show form and save
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Student s)
        {
            _context.Students.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // UPDATE: Show form and save changes
        public IActionResult Edit(int id)
        {
            var s = _context.Students.Find(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult Edit(Student s)
        {
            _context.Students.Update(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var s = _context.Students.Find(id);
            if (s != null)
            {
                _context.Students.Remove(s);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
} 