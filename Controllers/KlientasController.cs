using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrozioSalonuISCF.Controllers
{
    public class KlientasController : Controller
    {
        [Authorize(Roles = "Klientas")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Klientas")]
        public IActionResult KomentaruLangas()
        {
            return View();
        }

        [Authorize(Roles = "Klientas")]
        public IActionResult Paslaugos()
        {
            return View();
        }

        [Authorize(Roles = "Klientas")]
        public IActionResult Redagavimas()
        {
            return View();
        }

        [Authorize(Roles = "Klientas")]
        public IActionResult RezervacijosPatvirtinimas()
        {
            return View();
        }

        [Authorize(Roles = "Klientas")]
        public IActionResult UzsakymoLangas()
        {
            return View();
        }

        [Authorize(Roles = "Klientas")]
        public IActionResult UzsakytosPaslaugos()
        {
            return View();
        }
    }
}
