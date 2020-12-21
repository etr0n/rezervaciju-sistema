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
    public class RezervacijaSalonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaSalonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RezervacijaSalonas
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salonasId = _context.Salonas.Where(s => s.UserId == userId).First().SalonasId;
            var applicationDbContext = _context.Rezervacija.Include(r => r.Paslauga).Include(r => r.User).Where(r => r.Paslauga.SalonasId == salonasId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RezervacijaSalonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Paslauga)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RezervacijaId == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: RezervacijaSalonas/Create
        public IActionResult Create()
        {
            ViewData["PaslaugaId"] = new SelectList(_context.Paslauga, "PaslaugaId", "PaslaugaId");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: RezervacijaSalonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervacijaId,proc_prad,data,busena,UserId,PaslaugaId")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaslaugaId"] = new SelectList(_context.Paslauga, "PaslaugaId", "PaslaugaId", rezervacija.PaslaugaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", rezervacija.UserId);
            return View(rezervacija);
        }

        // GET: RezervacijaSalonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewData["PaslaugaId"] = new SelectList(_context.Paslauga, "PaslaugaId", "pavadinimas", rezervacija.PaslaugaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "UserName", rezervacija.UserId);
            return View(rezervacija);
        }

        // POST: RezervacijaSalonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezervacijaId,proc_prad,data,busena,UserId,PaslaugaId")] Rezervacija rezervacija)
        {
            if (id != rezervacija.RezervacijaId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.RezervacijaId))
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
            ViewData["PaslaugaId"] = new SelectList(_context.Paslauga, "PaslaugaId", "pavadinimas", rezervacija.PaslaugaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "UserName", rezervacija.UserId);
            return View(rezervacija);
        }

        // GET: RezervacijaSalonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Paslauga)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RezervacijaId == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: RezervacijaSalonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.RezervacijaId == id);
        }
    }
}
