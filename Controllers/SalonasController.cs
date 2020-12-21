using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrozioSalonuISCF.Data;
using GrozioSalonuISCF.Models;
using System.Security.Claims;

namespace GrozioSalonuISCF.Controllers
{
    public class SalonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Salonas
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationDbContext = _context.Salonas.Include(s => s.Miestas).Include(s => s.User).Where(s => s.UserId == userId);
           if (applicationDbContext.Count() == 0)
           {
                ViewBag.Message = string.Format("Nera");
           }
           
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Salonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salonas = await _context.Salonas
                .Include(s => s.Miestas)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SalonasId == id);
            if (salonas == null)
            {
                return NotFound();
            }

            return View(salonas);
        }

        // GET: Salonas/Create
        public IActionResult Create()
        {
            ViewData["MiestasId"] = new SelectList(_context.Miestas, "MiestasId", "pavadinimas");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Salonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalonasId,pavadinimas,imones_kodas,adresas,tel_nr,email,ikurimo_data,password,MiestasId,UserId")] Salonas salonas)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            salonas.UserId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(salonas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MiestasId"] = new SelectList(_context.Miestas, "MiestasId", "pavadinimas", salonas.MiestasId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", salonas.UserId);
            return View(salonas);
        }

        // GET: Salonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salonas = await _context.Salonas.FindAsync(id);
            if (salonas == null)
            {
                return NotFound();
            }
            ViewData["MiestasId"] = new SelectList(_context.Miestas, "MiestasId", "pavadinimas", salonas.MiestasId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", salonas.UserId);
            return View(salonas);
        }

        // POST: Salonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalonasId,pavadinimas,imones_kodas,adresas,tel_nr,email,ikurimo_data,password,MiestasId,UserId")] Salonas salonas)
        {

            if (id != salonas.SalonasId)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            salonas.UserId = userId;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salonas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalonasExists(salonas.SalonasId))
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
            ViewData["MiestasId"] = new SelectList(_context.Miestas, "MiestasId", "pavadinimas", salonas.MiestasId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", salonas.UserId);
            return View(salonas);
        }

        // GET: Salonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salonas = await _context.Salonas
                .Include(s => s.Miestas)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SalonasId == id);
            if (salonas == null)
            {
                return NotFound();
            }

            return View(salonas);
        }

        // POST: Salonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salonas = await _context.Salonas.FindAsync(id);
            _context.Salonas.Remove(salonas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalonasExists(int id)
        {
            return _context.Salonas.Any(e => e.SalonasId == id);
        }
    }
}
