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
    public class AtsiliepimasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtsiliepimasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atsiliepimas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atsiliepimas.ToListAsync());
        }

        // GET: Atsiliepimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atsiliepimas = await _context.Atsiliepimas
                .FirstOrDefaultAsync(m => m.AtsiliepimasId == id);
            if (atsiliepimas == null)
            {
                return NotFound();
            }

            return View(atsiliepimas);
        }

        // GET: Atsiliepimas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atsiliepimas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtsiliepimasId,aprasymas,paslaugos_busena,data,vardas,PaslaugosId")] Atsiliepimas atsiliepimas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atsiliepimas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atsiliepimas);
        }

        // GET: Atsiliepimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atsiliepimas = await _context.Atsiliepimas.FindAsync(id);
            if (atsiliepimas == null)
            {
                return NotFound();
            }
            return View(atsiliepimas);
        }

        // POST: Atsiliepimas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AtsiliepimasId,aprasymas,paslaugos_busena,data,vardas,PaslaugosId")] Atsiliepimas atsiliepimas)
        {
            if (id != atsiliepimas.AtsiliepimasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atsiliepimas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtsiliepimasExists(atsiliepimas.AtsiliepimasId))
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
            return View(atsiliepimas);
        }

        // GET: Atsiliepimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atsiliepimas = await _context.Atsiliepimas
                .FirstOrDefaultAsync(m => m.AtsiliepimasId == id);
            if (atsiliepimas == null)
            {
                return NotFound();
            }

            return View(atsiliepimas);
        }

        // POST: Atsiliepimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atsiliepimas = await _context.Atsiliepimas.FindAsync(id);
            _context.Atsiliepimas.Remove(atsiliepimas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtsiliepimasExists(int id)
        {
            return _context.Atsiliepimas.Any(e => e.AtsiliepimasId == id);
        }
    }
}
