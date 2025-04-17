using System.Diagnostics;
using BloodDonor.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public BloodDbContext _context;

        public HomeController(ILogger<HomeController> logger, BloodDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        { 
            var blood = _context.Bloods.ToList();
            return View(blood);

        }
        [HttpGet]
        public IActionResult Search(string bldg)
        {
            var blood = _context.Bloods.Where(b=>b.BloodType==bldg).ToList();
            if (blood == null)
            {
                return NotFound();
            }
            return View(blood);
        }
        public IActionResult Create() => View("Create");

        [HttpPost]
        public IActionResult Create(Blood model)
        {
            _context.Bloods.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blood = _context.Bloods.Find(id);
            if (blood == null)
            {
                return NotFound();
            }
            return View(blood);
        }
        [HttpPost]
        public IActionResult Edit(Blood model)
        {
            if (ModelState.IsValid)
            {
                _context.Bloods.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            var blood = _context.Bloods.Find(id);
            if (blood == null)
            {
                return NotFound();
            }
            return View(blood);
        }
        [HttpPost]
        public IActionResult Deleted(int id)
        {
            var blood = _context.Bloods.FirstOrDefault(x=>x.Id==id);
            if (blood != null)
            {
                _context.Bloods.Remove(blood);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
