using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo_Vista_Controlador.DBase;
using Modelo_Vista_Controlador.Models;
using System.Diagnostics;

namespace Modelo_Vista_Controlador.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDBase _context;

        public HomeController(MyDBase context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact.ToListAsync());
        }

        // [HttpGet]
        // public async Task<IActionResult> Privacy()
        // {
            // return View(await _context.Contact.ToListAsync());
        // }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contact.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contact.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteIt(int? id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if(contact == null)
            {
                return View();
            }
            
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}