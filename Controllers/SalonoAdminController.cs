using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrozioSalonuISCF.Controllers
{
    public class SalonoAdminController : Controller
    {
        [Authorize(Roles = "Salono Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Salono Admin")]
        public IActionResult Ataskaitos()
        {
            return View();
        }

        [Authorize(Roles = "Salono Admin")]
        public IActionResult Paslaugos()
        {
            return View();
        }

        [Authorize(Roles = "Salono Admin")]
        public IActionResult PaslauguRedagavimas()
        {
            return View();
        }

        [Authorize(Roles = "Salono Admin")]
        public IActionResult KlientuRezervacijos()
        {
            return View();
        }

        [Authorize(Roles = "Salono Admin")]
        public IActionResult DarbuotojuRedagavimas()
        {
            return View();
        }
        [Authorize(Roles = "Salono Admin")]
        public IActionResult Darbuotojai()
        {
            return View();
        }
    }
}
