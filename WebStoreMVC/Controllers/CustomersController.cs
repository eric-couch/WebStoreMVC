using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreMVC.Data;
using WebStoreMVC.Interfaces;
using WebStoreMVC.Models;
using WebStoreMVC.Services;

namespace WebStoreMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly StoreContext _context;
        private readonly IDateTime _dateTime;

        public CustomersController(StoreContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        [Route("get-datetime")]
        public IActionResult GetDateTime()
        {
            return Json(_dateTime.Now);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || _context.Customers is null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            return View(customer);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Phone,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Phone,Email")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || _context.Customers is null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
