using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class RegistroDeVendasController : Controller
    {

        private readonly RegistroDeVendasService _registroDeVendasService;
        public RegistroDeVendasController(RegistroDeVendasService registroDeVendas)
        {
            _registroDeVendasService = registroDeVendas;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> BuscaSimples(DateTime? dataMinima, DateTime? dataMaxima)
        {
            //isso vai mostra um valor padrão la no formulario de filtrar
            if (!dataMinima.HasValue)
            {
                dataMinima =  new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataMaxima.HasValue)
            {
                dataMaxima = DateTime.Now;
            }

            ViewData["dataMinima"] = dataMinima.Value.ToString("yyyy-MM-dd");
            ViewData["dataMaxima"] = dataMaxima.Value.ToString("yyyy-MM-dd");
            var result = await _registroDeVendasService.EncontrarPorData(dataMinima,dataMaxima);
            return View(result);
        }
        public IActionResult PesquisaAgrupada()
        {
            return View();
        }
    }
}
