using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrozioSalonuISCF.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult SalonuSarasas()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AtaskaituLangas()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult KlientaiRedagavimas()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult SalonaiRedagavimas()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Redagavimas()
        {
            return View();
        }
    }
}
