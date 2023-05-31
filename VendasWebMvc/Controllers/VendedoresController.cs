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
        public async Task<IActionResult> Index()
        {
            var lista = await _vendedorServices.EncontrarTudo();

            return View(lista);
        }

        public async Task<IActionResult> Create()
        {
            var departaments = await _departamentoServices.EncontraTodosDepartamentos();
            var viewModel = new VendedorFormVielModel { Departamentos = departaments };

            return View(viewModel);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não fornecido!" });
            }

            var obj = await _vendedorServices.EncontraPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Encontrado!" });

            }
            return View(obj);
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Fornecido!" });
            }

            var obj = await _vendedorServices.EncontraPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Encontrado!" });

            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Não fornecido!" });
            }

            var obj = await _vendedorServices.EncontraPorId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não Encontrado!" }); ;
            }
            List<Departamento> Departamento = await _departamentoServices.EncontraTodosDepartamentos();
            VendedorFormVielModel viewlModel = new VendedorFormVielModel { Vendedor = obj, Departamentos = Departamento };
            return View(viewlModel);
        }

        //Ações POST
        [HttpPost]
        [ValidateAntiForgeryToken]// Ler mais sobe depois
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid) // Evita de cadastros em Branco, por falta do javaScritp
            {
                var departamentos = await _departamentoServices.EncontraTodosDepartamentos();
                var viewModel = new VendedorFormVielModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            await _vendedorServices.Inserir(vendedor);
            return RedirectToAction(nameof(Index));//Quando salvar volta pra o index da pagina vendedores
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                await _vendedorServices.RemoverPorId(id);
                return RedirectToAction(nameof(Index));

            }
            catch (IntegrityException e)
            {

                return RedirectToAction(nameof(Error), new { messagem = e.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {

            if (!ModelState.IsValid) // Evita de cadastros em Branco, por falta do javaScritp
            {
                var departamentos = await _departamentoServices.EncontraTodosDepartamentos();
                var viewModel = new VendedorFormVielModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { menssage = "ID não é correspondente.!" });
            }
            try
            {
                await _vendedorServices.EditarPorId(vendedor);
                return RedirectToAction(nameof(Index));

            }
            catch (NotFoundException e)
            {

                return RedirectToAction(nameof(Error), new { menssage = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { menssage = e.Message });
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
