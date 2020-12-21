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
    public class DarbuotojasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DarbuotojasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Darbuotojas
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Darbuotojas.Include(d => d.Salonas);

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salonasId = _context.Salonas.Where(s => s.UserId == userId).First().SalonasId;
           
            var darb =await _context.Darbuotojas.Where(e => e.SalonasId == salonasId).ToListAsync();
            
           
            if (darb.Count() == 0)
            {
                ViewBag.Message = string.Format("Nera");
            }

            return View(darb);
        }

        // GET: Darbuotojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var darbuotojas = await _context.Darbuotojas
                .Include(d => d.Salonas)
                .FirstOrDefaultAsync(m => m.DarbuotojasId == id);
            if (darbuotojas == null)
            {
                return NotFound();
            }

            return View(darbuotojas);
        }

        // GET: Darbuotojas/Create
        public IActionResult Create()
        {
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId");
            return View();
        }

        // POST: Darbuotojas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DarbuotojasId,vardas,pavarde,tel_nr,email,adresas,gimimo_data,stazas,pareigos,SalonasId")] Darbuotojas darbuotojas)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salonasId = _context.Salonas.Where(s => s.UserId == userId).First().SalonasId;
            darbuotojas.SalonasId = salonasId;

            if (ModelState.IsValid)
            {
                _context.Add(darbuotojas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId", darbuotojas.SalonasId);
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var darbuotojas = await _context.Darbuotojas.FindAsync(id);
            if (darbuotojas == null)
            {
                return NotFound();
            }
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId", darbuotojas.SalonasId);
            return View(darbuotojas);
        }

        // POST: Darbuotojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DarbuotojasId,vardas,pavarde,tel_nr,email,adresas,gimimo_data,stazas,pareigos,SalonasId")] Darbuotojas darbuotojas)
        {
            if (id != darbuotojas.DarbuotojasId)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salonasId = _context.Salonas.Where(s => s.UserId == userId).First().SalonasId;
   
            
            darbuotojas.SalonasId = salonasId;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(darbuotojas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DarbuotojasExists(darbuotojas.DarbuotojasId))
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
            ViewData["SalonasId"] = new SelectList(_context.Salonas, "SalonasId", "SalonasId", darbuotojas.SalonasId);
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var darbuotojas = await _context.Darbuotojas
                .Include(d => d.Salonas)
                .FirstOrDefaultAsync(m => m.DarbuotojasId == id);
            if (darbuotojas == null)
            {
                return NotFound();
            }

            return View(darbuotojas);
        }

        // POST: Darbuotojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var darbuotojas = await _context.Darbuotojas.FindAsync(id);
            _context.Darbuotojas.Remove(darbuotojas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DarbuotojasExists(int id)
        {
            return _context.Darbuotojas.Any(e => e.DarbuotojasId == id);
        }
    }
}
