using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorServices _vendedorServices;
        public VendedoresController(VendedorServices vendedorServices)
        {
            _vendedorServices = vendedorServices;
        }
        public IActionResult Index()
        {
            var lista = _vendedorServices.EncontrarTudo();

            return View(lista);
        }
    }
}
