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
    public class AdminSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminS
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Salonas.Include(s => s.Miestas).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AdminS/Details/5
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

        // GET: AdminS/Create
        public IActionResult Create()
        {
            ViewData["MiestasId"] = new SelectList(_context.Miestas, "MiestasId", "MiestasId");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: AdminS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalonasId,pavadinimas,imones_kodas,adresas,tel_nr,email,ikurimo_data,password,MiestasId,UserId")] Salonas salonas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salonas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MiestasId"] = new SelectList(_context.Miestas, "MiestasId", "MiestasId", salonas.MiestasId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", salonas.UserId);
            return View(salonas);
        }

        // GET: AdminS/Edit/5
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
            ViewData["MiestasId"] = new SelectList(_context.Miestas, "MiestasId", "MiestasId", salonas.MiestasId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", salonas.UserId);
            return View(salonas);
        }

        // POST: AdminS/Edit/5
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
            ViewData["MiestasId"] = new SelectList(_context.Miestas, "MiestasId", "MiestasId", salonas.MiestasId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", salonas.UserId);
            return View(salonas);
        }

        // GET: AdminS/Delete/5
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

        // POST: AdminS/Delete/5
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

        public async Task<ActionResult> CreateDocument()
        {

            //Create a new PDF document. 
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            PdfGraphics graphics = page.Graphics;


            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            //Draw the text.

            graphics.DrawString("Einamojo menesio ataskaita", font, PdfBrushes.Black, new PointF(190, 20));
            graphics.DrawString("Parengta: " + DateTime.Today.ToShortDateString(), font2, PdfBrushes.Black, new PointF(215, 40));


            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to list
            List<object> data = new List<object>();

            var miestas = await _context.Miestas.ToListAsync();
            var salonas = await _context.Salonas.ToListAsync();
            var islaidos = await _context.Islaidos.ToListAsync();
            foreach (var m in miestas)
            {
                var k = 0;
                float suma = 0;
                var ik = 0;
                foreach (var s in salonas)
                {
                    if (m.MiestasId == s.MiestasId)
                        k++;
                    foreach (var i in islaidos)
                    {
                        if (i.data.Month == DateTime.Today.Month)
                        {
                            if (m.MiestasId == s.MiestasId && s.SalonasId == i.SalonasId)
                            {
                                suma += i.suma;
                                ik++;
                            }
                        }
                    }
                }
                var row = new { Miestas = m.pavadinimas, Salonu_kiekis = k, Islaidu_kiekis = ik, Islaidu_suma = suma };
                data.Add(row);
            }

            //Add list to IEnumerable
            IEnumerable<object> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 80));

           

            //Save the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";
            //Define the file name.
            string fileName = "Output.pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);

        }


        public async Task<IActionResult> Atranka() 
        { 
            var applicationDbContext = _context.Salonas.Include(s => s.Miestas).Include(s => s.Paslauga);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
