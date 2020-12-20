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
    public class PaslaugaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaslaugaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Paslauga
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Paslauga.Include(p => p.Darbuotojas).Include(p => p.PaslaugosTipas).Include(p => p.Salonas);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Paslauga/Details/5
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

        // GET: Paslauga/Create
        public IActionResult Create()
        {
            /*ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId");
            ViewData["PaslaugosTipasId"] = new SelectList(_context.PaslaugosTipas, "PaslaugosTipasId", "PaslaugosTipasId");
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId");*/
            return View();
        }

        // POST: Paslauga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaslaugaId,pavadinimas,aprasymas,kaina,trukme,priemones,rekomendacijos,DarbuotojasId,SalonasId,PaslaugosTipasId")] Paslauga paslauga)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(paslauga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId", paslauga.DarbuotojasId);
            ViewData["PaslaugosTipasId"] = new SelectList(_context.PaslaugosTipas, "PaslaugosTipasId", "PaslaugosTipasId", paslauga.PaslaugosTipasId);
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId", paslauga.SalonasId);
            return View(paslauga);
        }*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervacijaId,proc_prad,data,busenos,UserId,PaslaugaId")] Rezervacija rezervacija, int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            rezervacija.data = DateTime.Now;
            rezervacija.busenos = true;
            rezervacija.PaslaugaId = id;
            rezervacija.UserId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           /* ViewData["PaslaugaId"] = new SelectList(_context.Paslauga, "PaslaugaId", "PaslaugaId", rezervacija.PaslaugaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", rezervacija.UserId);*/
            return View(rezervacija);
        }

        // GET: Paslauga/Edit/5
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
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId", paslauga.DarbuotojasId);
            ViewData["PaslaugosTipasId"] = new SelectList(_context.PaslaugosTipas, "PaslaugosTipasId", "PaslaugosTipasId", paslauga.PaslaugosTipasId);
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId", paslauga.SalonasId);
            return View(paslauga);
        }

        // POST: Paslauga/Edit/5
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
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId", paslauga.DarbuotojasId);
            ViewData["PaslaugosTipasId"] = new SelectList(_context.PaslaugosTipas, "PaslaugosTipasId", "PaslaugosTipasId", paslauga.PaslaugosTipasId);
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId", paslauga.SalonasId);
            return View(paslauga);
        }

        // GET: Paslauga/Delete/5
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

        // POST: Paslauga/Delete/5
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
