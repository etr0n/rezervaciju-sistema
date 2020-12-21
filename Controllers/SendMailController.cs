using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrozioSalonuISCF.Models;
using System.Net.Mail;

namespace GrozioSalonuISCF.Controllers
{
    public class SendMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Email em)
        {
            string to = em.To;
            string subject = em.Subject;
            string body = em.Body;
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("rezervacijusistema@gmail.com");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("klientas933@gmail.com", "klient@S!");
            smtp.Send(mm);
            ViewBag.message = "The mail has been sent to" + em.To + "sucessfully";
            return View();
        }
    }
}
