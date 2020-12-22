using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrozioSalonuISCF.Data;
using GrozioSalonuISCF.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Grid;
using System.Data;
using Syncfusion.Pdf.Tables;
using Microsoft.AspNetCore.Hosting;

namespace GrozioSalonuISCF.Controllers
{
    public class AdminMController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminMController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminM
        public async Task<IActionResult> Index()
        {
            return View(await _context.Miestas.ToListAsync());
        }

        // GET: AdminM/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miestas = await _context.Miestas
                .FirstOrDefaultAsync(m => m.MiestasId == id);
            if (miestas == null)
            {
                return NotFound();
            }

            return View(miestas);
        }

        // GET: AdminM/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MiestasId,pavadinimas")] Miestas miestas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miestas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miestas);
        }

        // GET: AdminM/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miestas = await _context.Miestas.FindAsync(id);
            if (miestas == null)
            {
                return NotFound();
            }
            return View(miestas);
        }

        // POST: AdminM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MiestasId,pavadinimas")] Miestas miestas)
        {
            if (id != miestas.MiestasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miestas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiestasExists(miestas.MiestasId))
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
            return View(miestas);
        }

        // GET: AdminM/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miestas = await _context.Miestas
                .FirstOrDefaultAsync(m => m.MiestasId == id);
            if (miestas == null)
            {
                return NotFound();
            }

            return View(miestas);
        }

        // POST: AdminM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miestas = await _context.Miestas.FindAsync(id);
            _context.Miestas.Remove(miestas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiestasExists(int id)
        {
            return _context.Miestas.Any(e => e.MiestasId == id);
        }
    }
}
