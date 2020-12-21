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
    public class PaslaugasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaslaugasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Paslaugas
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salonasId = _context.Salonas.Where(s => s.UserId == userId).First().SalonasId;
            var applicationDbContext = _context.Paslauga.Include(p => p.Darbuotojas).Include(p => p.PaslaugosTipas).Include(p => p.Salonas).Where(e=>e.SalonasId == salonasId);
            if (applicationDbContext.Count() == 0)
            {
                ViewBag.Message = string.Format("Nera");
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Paslaugas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paslauga = await _context.Paslauga
                .Include(p => p.Darbuotojas)
                .Include(p => p.PaslaugosTipas)
                .Include(p => p.Salonas)
                .FirstOrDefaultAsync(m => m.PaslaugaId == id);
            if (paslauga == null)
            {
                return NotFound();
            }

            return View(paslauga);
        }

        // GET: Paslaugas/Create
        public IActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salonasId = _context.Salonas.Where(s => s.UserId == userId).First().SalonasId;
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas.Where(e => e.SalonasId == salonasId), "DarbuotojasId", "pavarde");
            ViewData["PaslaugosTipasId"] = new SelectList(_context.PaslaugosTipas, "PaslaugosTipasId", "pavadinimas");
           // ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId");
            return View();
        }

        // POST: Paslaugas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaslaugaId,pavadinimas,aprasymas,kaina,trukme,priemones,rekomendacijos,DarbuotojasId,SalonasId,PaslaugosTipasId")] Paslauga paslauga)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salonasId = _context.Salonas.Where(s => s.UserId == userId).First().SalonasId;
            paslauga.SalonasId = salonasId;
            
            if (ModelState.IsValid)
            {
                _context.Add(paslauga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas.Where(e => e.SalonasId == salonasId), "DarbuotojasId", "pavarde" , paslauga.DarbuotojasId);
            ViewData["PaslaugosTipasId"] = new SelectList(_context.PaslaugosTipas, "PaslaugosTipasId", "pavadinimas", paslauga.PaslaugosTipasId);
           // ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId", paslauga.SalonasId);
            return View(paslauga);
        }

        // GET: Paslaugas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paslauga = await _context.Paslauga.FindAsync(id);
            if (paslauga == null)
            {
                return NotFound();
            }
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "pavarde", paslauga.DarbuotojasId);
            ViewData["PaslaugosTipasId"] = new SelectList(_context.PaslaugosTipas, "PaslaugosTipasId", "pavadinimas", paslauga.PaslaugosTipasId);
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId", paslauga.SalonasId);
            return View(paslauga);
        }

        // POST: Paslaugas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaslaugaId,pavadinimas,aprasymas,kaina,trukme,priemones,rekomendacijos,DarbuotojasId,SalonasId,PaslaugosTipasId")] Paslauga paslauga)
        {
            if (id != paslauga.PaslaugaId)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salonasId = _context.Salonas.Where(s => s.UserId == userId).First().SalonasId;
            paslauga.SalonasId = salonasId;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paslauga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaslaugaExists(paslauga.PaslaugaId))
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
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "pavarde", paslauga.DarbuotojasId);
            ViewData["PaslaugosTipasId"] = new SelectList(_context.PaslaugosTipas, "PaslaugosTipasId", "pavadinimas", paslauga.PaslaugosTipasId);
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId", paslauga.SalonasId);
            return View(paslauga);
        }

        // GET: Paslaugas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paslauga = await _context.Paslauga
                .Include(p => p.Darbuotojas)
                .Include(p => p.PaslaugosTipas)
                .Include(p => p.Salonas)
                .FirstOrDefaultAsync(m => m.PaslaugaId == id);
            if (paslauga == null)
            {
                return NotFound();
            }

            return View(paslauga);
        }

        // POST: Paslaugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paslauga = await _context.Paslauga.FindAsync(id);
            _context.Paslauga.Remove(paslauga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaslaugaExists(int id)
        {
            return _context.Paslauga.Any(e => e.PaslaugaId == id);
        }
    }
}
