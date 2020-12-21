using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrozioSalonuISCF.Data;
using GrozioSalonuISCF.Models;

namespace GrozioSalonuISCF.Controllers
{
    public class RezervacijaKlientasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaKlientasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RezervacijaKlientas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rezervacija.Include(r => r.Atsiliepimas).Include(r => r.Paslauga).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RezervacijaKlientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Atsiliepimas)
                .Include(r => r.Paslauga)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RezervacijaId == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: RezervacijaKlientas/Create
        public IActionResult Create()
        {
            ViewData["AtsiliepimasId"] = new SelectList(_context.Atsiliepimas, "AtsiliepimasId", "AtsiliepimasId");
            ViewData["PaslaugaId"] = new SelectList(_context.Paslauga, "PaslaugaId", "PaslaugaId");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: RezervacijaKlientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("RezervacijaId,proc_prad,data,busena,AtsiliepimasId,UserId,PaslaugaId")] Rezervacija rezervacija, int id)
         {
             rezervacija.RezervacijaId = id;
             rezervacija.Atsiliepimas.paslaugos_busena = false;
             rezervacija.Atsiliepimas.data = DateTime.Now ;
             if (ModelState.IsValid)
             {
                 _context.Add(rezervacija);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             ViewData["AtsiliepimasId"] = new SelectList(_context.Atsiliepimas, "AtsiliepimasId", "AtsiliepimasId", rezervacija.AtsiliepimasId);
             ViewData["PaslaugaId"] = new SelectList(_context.Paslauga, "PaslaugaId", "PaslaugaId", rezervacija.PaslaugaId);
             ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", rezervacija.UserId);
             return View(rezervacija);
         }*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtsiliepimasId,aprasymas,paslaugos_busena,data,vardas,RezervacijaId")] Atsiliepimas atsiliepimas, int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);

            atsiliepimas.data = DateTime.Now;
            atsiliepimas.paslaugos_busena = false;
          
            if (ModelState.IsValid)
            {
               
                _context.Add(atsiliepimas);
               

                await _context.SaveChangesAsync();
               

                rezervacija.AtsiliepimasId = atsiliepimas.AtsiliepimasId;
                _context.Update(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atsiliepimas);
        }

        // GET: RezervacijaKlientas/Edit/5
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
            ViewData["AtsiliepimasId"] = new SelectList(_context.Atsiliepimas, "AtsiliepimasId", "AtsiliepimasId", rezervacija.AtsiliepimasId);
            ViewData["PaslaugaId"] = new SelectList(_context.Paslauga, "PaslaugaId", "PaslaugaId", rezervacija.PaslaugaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", rezervacija.UserId);
            return View(rezervacija);
        }

        // POST: RezervacijaKlientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezervacijaId,proc_prad,data,busena,AtsiliepimasId,UserId,PaslaugaId")] Rezervacija rezervacija)
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
            ViewData["AtsiliepimasId"] = new SelectList(_context.Atsiliepimas, "AtsiliepimasId", "AtsiliepimasId", rezervacija.AtsiliepimasId);
            ViewData["PaslaugaId"] = new SelectList(_context.Paslauga, "PaslaugaId", "PaslaugaId", rezervacija.PaslaugaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", rezervacija.UserId);
            return View(rezervacija);
        }

        // GET: RezervacijaKlientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Atsiliepimas)
                .Include(r => r.Paslauga)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RezervacijaId == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: RezervacijaKlientas/Delete/5
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
