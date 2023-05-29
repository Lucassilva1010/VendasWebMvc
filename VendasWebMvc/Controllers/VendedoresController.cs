using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorServices _vendedorServices;
        private readonly DepartamentoServices _departamentoServices;
        public VendedoresController(VendedorServices vendedorServices, DepartamentoServices departamentoServices)
        {
            _vendedorServices = vendedorServices;
            _departamentoServices = departamentoServices;
        }
        public IActionResult Index()
        {
            var lista = _vendedorServices.EncontrarTudo();

            return View(lista);
        }

        public IActionResult Create()
        {
            var departaments = _departamentoServices.EncontraTodosDepartamentos();
            var viewModel = new VendedorFormVielModel { Departamentos = departaments };

            return View(viewModel);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("Esse ID não existe");
            }

            var obj = _vendedorServices.EncontraPorId(id.Value);

            if (obj == null)
            {
                return NotFound("Esse ID não existe");

            }
            return View(obj);
        }

        //Ações POST
        [HttpPost]
        [ValidateAntiForgeryToken]// Ler mais sobe depois
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorServices.Inserir(vendedor);
            return RedirectToAction(nameof(Index));//Quando salvar volta pra o index da pagina vendedores
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorServices.RemoverPorId(id);
            return RedirectToAction(nameof(Index));
        }


       


    }
}
