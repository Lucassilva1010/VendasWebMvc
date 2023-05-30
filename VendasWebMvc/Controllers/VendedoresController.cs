using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services;
using VendasWebMvc.Services.Exception;

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
                return RedirectToAction(nameof(Error), new { menssage = "ID não fornecido!"});
            }

            var obj = _vendedorServices.EncontraPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Encontrado!" });

            }
            return View(obj);
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Fornecido!" });
            }

            var obj = _vendedorServices.EncontraPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Encontrado!" });

            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Não fornecido!" });
            }

            var obj = _vendedorServices.EncontraPorId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Encontrado!" }); ;
            }
            List<Departamento> Departamento = _departamentoServices.EncontraTodosDepartamentos();
            VendedorFormVielModel viewlModel = new VendedorFormVielModel { Vendedor = obj, Departamentos = Departamento };
            return View(viewlModel);
        }

        //Ações POST
        [HttpPost]
        [ValidateAntiForgeryToken]// Ler mais sobe depois
        public IActionResult Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid) // Evita de cadastros em Branco, por falta do javaScritp
            {
                var departamentos = _departamentoServices.EncontraTodosDepartamentos();
                var viewModel = new VendedorFormVielModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {

            if (!ModelState.IsValid) // Evita de cadastros em Branco, por falta do javaScritp
            {
                var departamentos = _departamentoServices.EncontraTodosDepartamentos();
                var viewModel = new VendedorFormVielModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não é correspondente.!" });
            }
            try
            {
            _vendedorServices.EditarPorId(vendedor);
            return RedirectToAction(nameof(Index));

            }
            catch (NotFoundException e)
            {

                return RedirectToAction(nameof(Error), new { menssage = e.Message });
            }
            catch(DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { menssage =e.Message });
            }

        }
        public IActionResult Error(string mensaage)
        {
            var viewModel = new ErrorViewModel
            {
                Menssage = mensaage,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
      





    }
}
