using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Terminarz.Models;
using Terminarz.Data;
using Terminarz.ViewModels;

namespace Terminarz.Controllers
{
    public class HappeningsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HappeningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Happenings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Happenings.Include(h => h.Address);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Happenings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var happening = await _context.Happenings
                .Include(h => h.Address)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (happening == null)
            {
                return NotFound();
            }

            return View(happening);
        }

        // GET: Happenings/Create
        public IActionResult Create()   
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "DisplayAddress");
            return View();
        }
        public IActionResult CreateAddress()
        {
            Address address = new Address();
            return View(address);
        }


        // POST: Happenings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Priority,StartTime,EndTime,AddressID")] Happening happening)
        {
            if (ModelState.IsValid)
            {
                _context.Add(happening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "City", happening.AddressID);
            return View(happening);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAddress([Bind("ID,Street,City,PostCode,Number")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View();
        }
        /*   [HttpPost]
           [ValidateAntiForgeryToken]
           public async Task<IActionResult> CreateAddress(int? id, [Bind("ID,Priority,StartTime,EndTime, Address")] HappeningViewModel happening)
           {
               var happening = await _context.Happenings
                   .Include(h => h.Address)
                   .FirstOrDefaultAsync(m => m.ID == id);
               if (ModelState.IsValid)
               {
                   _context.Add(address);
                   await _context.SaveChangesAsync();
                   return RedirectToAction(nameof(Index));
               }
               return View(happening);
           }*/
        // GET: Happenings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var happening = await _context.Happenings.FindAsync(id);
            if (happening == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "City", happening.AddressID);
            return View(happening);
        }

        // POST: Happenings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Priority,StartTime,EndTime,AddressID")] Happening happening)
        {
            if (id != happening.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(happening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HappeningExists(happening.ID))
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "City", happening.AddressID);
            return View(happening);
        }

        // GET: Happenings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var happening = await _context.Happenings
                .Include(h => h.Address)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (happening == null)
            {
                return NotFound();
            }

            return View(happening);
        }

        // POST: Happenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var happening = await _context.Happenings.FindAsync(id);
            _context.Happenings.Remove(happening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HappeningExists(int id)
        {
            return _context.Happenings.Any(e => e.ID == id);
        }
    }
}
