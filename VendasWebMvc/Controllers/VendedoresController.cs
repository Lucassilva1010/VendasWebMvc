using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
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

        public IActionResult Create()
        {
            return View();
        }


        //Ações POST
        [HttpPost]
        [ValidateAntiForgeryToken]// Ler mais sobe depois
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorServices.Inserir(vendedor);
            return RedirectToAction(nameof(Index));//Quando salvar volta pra o index da pagina vendedores
        }

    }
}
