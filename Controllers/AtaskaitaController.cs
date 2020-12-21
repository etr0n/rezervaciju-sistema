
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
using Microsoft.AspNetCore.Http;
using Syncfusion.Pdf.Grid;
using System.Security.Claims;

namespace GrozioSalonuISCF.Controllers
{
    public class AtaskaitaController : Controller
    {
       
        private readonly ApplicationDbContext _context;

        public AtaskaitaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult CreateDocument()
        {
            
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();

          
            PdfGraphics graphics = page.Graphics;
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 18);
            PdfTextElement element = new PdfTextElement("Salono Ataskaita ", subHeadingFont);
            PdfLayoutResult result = element.Draw(page, new PointF(205,40));
            PdfFont subHeadingFontdata = new PdfStandardFont(PdfFontFamily.TimesRoman, 11);
            PdfTextElement dataNow = new PdfTextElement("Data "+ DateTime.Now.ToString("MM/dd/yyyy"), subHeadingFontdata);
            PdfLayoutResult resultdata = dataNow.Draw(page, new PointF(230, result.Bounds.Bottom + 8));

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salonasId = _context.Salonas.Where(s => s.UserId == userId).First().SalonasId;
            var dat = _context.Islaidos.Include(r => r.Salonas).Where(r=>r.SalonasId==salonasId).ToList();
            List<object> data = new List<object>();
            int index = 0;
            float bendrasuma = 0;
            foreach(var d in dat)
            {
                index++;
                bendrasuma += d.suma;
                object row = new {Nr=index, Data = d.data, Paskirtis = d.paskirtis, Suma = d.suma };
                data.Add(row);
            }
            //Add list to IEnumerable
            IEnumerable<object> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Draw grid to the page of PDF document.
            PdfLayoutResult lenta = pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, resultdata.Bounds.Bottom+50));
            
            PdfFont subHeadingFontSuma = new PdfStandardFont(PdfFontFamily.TimesRoman, 11);
            PdfTextElement suma = new PdfTextElement("Bendra suma yra lygi:  " + bendrasuma+" eurai", subHeadingFontdata);
            PdfLayoutResult resultsuma = suma.Draw(page, new PointF(200, lenta.Bounds.Bottom + 50));

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
            string fileName = "Ataskaita.pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);
        }
        public IActionResult Index()
        {
            
            return View();
        }

        // GET: AtaskaitaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AtaskaitaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AtaskaitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AtaskaitaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AtaskaitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AtaskaitaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AtaskaitaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
